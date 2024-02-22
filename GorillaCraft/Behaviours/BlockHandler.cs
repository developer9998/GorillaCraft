using GorillaCraft.Behaviours.Block;
using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Factories;
using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using GorillaExtensions;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace GorillaCraft.Behaviours
{
    public class BlockHandler : MonoBehaviourPunCallbacks
    {
        private bool Initialized;

        private AssetLoader AssetLoader;
        private BlockDataFactory_PL Factory;

        private List<IBlock> BlockList;

        private Dictionary<IBlock, GameObject> BlockDictionary;
        private GameObject BlockTemplate, ParticleTemplate;

        private Dictionary<Type, IDataType> FootstepSound_Cache, InteractionSound_Cache;

        private PhysicMaterial Slippery;

        private Dictionary<Vector3, BlockParent> BlockLocations;

        [Inject]
        public async void Construct(AssetLoader assetLoader, List<IBlock> blockList, BlockDataFactory_PL factory)
        {
            if (Initialized) return;
            Initialized = true;

            AssetLoader = assetLoader;
            Factory = factory;

            BlockList = blockList;

            Slippery = new PhysicMaterial
            {
                dynamicFriction = 0,
                staticFriction = 0,
                bounciness = 0,
                frictionCombine = PhysicMaterialCombine.Minimum,
                bounceCombine = PhysicMaterialCombine.Minimum
            };

            // Define lists, dictionaries, etc.
            BlockLocations = new();
            FootstepSound_Cache = new Dictionary<Type, IDataType>();
            InteractionSound_Cache = new Dictionary<Type, IDataType>();
            BlockDictionary = new Dictionary<IBlock, GameObject>();

            BlockTemplate = await AssetLoader.LoadAsset<GameObject>(Constants.BlockName);
            ParticleTemplate = await AssetLoader.LoadAsset<GameObject>(Constants.ParticleName);

            async Task<BlockFace> PrepareFace(GameObject currentObject, Material[] materialArray, string name, int materialIndex, BlockFaceInfo info, BlockParent _blockParent)
            {
                materialArray[materialIndex] = await AssetLoader.LoadAsset<Material>(info.FaceName);

                Transform relativeFace = currentObject.transform.Find("Collider/" + name);
                relativeFace.GetComponent<Collider>().material = info.IsSlippery ? Slippery : relativeFace.GetComponent<Collider>().material;

                BlockFace blockFace = relativeFace.gameObject.AddComponent<BlockFace>();
                blockFace.baseBlock = _blockParent;
                blockFace.surfaceType = info.FaceSurfaceType;

                GorillaSurfaceOverride surface = relativeFace.gameObject.AddComponent<GorillaSurfaceOverride>();
                surface.overrideIndex = info.FaceSurfaceType == typeof(Interaction_Snow) ? 32 : 0;

                return blockFace;
            }

            foreach (IBlock _currentBlock in BlockList)
            {
                GameObject _currentObject = Instantiate(BlockTemplate);

                _currentObject.name = _currentBlock.BlockDefinition;
                _currentObject.transform.localPosition = Vector3.zero;

                MeshRenderer _rendererObject = _currentObject.transform.Find("Optimized Block").GetComponent<MeshRenderer>();
                Material[] _materialArray = _rendererObject.materials;

                BlockParent _blockParent = _currentObject.AddComponent<BlockParent>();
                _blockParent.Back = await PrepareFace(_currentObject, _materialArray, "Back", 0, _currentBlock.Back, _blockParent);
                _blockParent.Left = await PrepareFace(_currentObject, _materialArray, "Left", 1, _currentBlock.Left, _blockParent);
                _blockParent.Front = await PrepareFace(_currentObject, _materialArray, "Front", 2, _currentBlock.Front, _blockParent);
                _blockParent.Right = await PrepareFace(_currentObject, _materialArray, "Right", 3, _currentBlock.Right, _blockParent);
                _blockParent.Bottom = await PrepareFace(_currentObject, _materialArray, "Bottom", 4, _currentBlock.Down, _blockParent);
                _blockParent.Top = await PrepareFace(_currentObject, _materialArray, "Top", 5, _currentBlock.Up, _blockParent);

                _rendererObject.materials = _materialArray;
                BlockDictionary.Add(_currentBlock, _currentObject);
                _currentObject.SetActive(false);
            }
        }

        public bool PlaceBlock(BlockPlaceType placeType, string block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale, Player player) => PlaceBlock(placeType, BlockList.First(a => a.GetType().Name == block), blockPosition, blockEuler, blockScale, player);

        private bool PlaceBlock(BlockPlaceType placeType, IBlock block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale, Player player)
        {
            // Run a check if any player with the mod would be suffocated / trapped by this block
            if (placeType == BlockPlaceType.Local)
            {
                Bounds bounds = new(blockPosition, blockScale);

                VRRig LocalRig = GorillaTagger.Instance.offlineVRRig;
                SphereCollider headCollider = LocalRig.headMesh.transform.Find("SpeakerHeadCollider").GetComponent<SphereCollider>();
                CapsuleCollider bodyCollider = LocalRig.headMesh.transform.parent.Find("BodyTrigger").GetComponent<CapsuleCollider>();

                if (bounds.Intersects(headCollider.bounds) || bounds.Intersects(bodyCollider.bounds)) return false;
            }

            // Run a check if there is already an existing block at this point
            if (BlockLocations.ContainsKey(blockPosition)) return false;

            // Run a check if a "base-block" exists for this block type / interface
            if (!BlockDictionary.TryGetValue(block, out GameObject baseBlock)) return false;
            BlockParent originalParent = baseBlock.GetComponent<BlockParent>();

            GameObject newBlock = Instantiate(baseBlock);
            newBlock.SetActive(true);
            newBlock.transform.position = blockPosition;
            newBlock.transform.eulerAngles = blockEuler;
            newBlock.transform.localScale = blockScale;

            async void PlaySound_Place(IDataType currentPlaceSound)
            {
                AudioSource placeSource = newBlock.AddComponent<AudioSource>();
                string currentSound = string.Concat("Dig_", currentPlaceSound.Name, UnityEngine.Random.Range(1, currentPlaceSound.MaxRange - 1));
                placeSource.spatialBlend = 1f;
                placeSource.clip = await AssetLoader.LoadAsset<AudioClip>(currentSound);
                placeSource.volume = currentPlaceSound.Volume / 4f;
                placeSource.pitch = currentPlaceSound.Pitch;
                placeSource.Play();
                Destroy(placeSource, 4);
            }

            if (placeType != BlockPlaceType.Recovery) PlaySound_Place(GetPlaceType(block.PlaceSoundType));

            BlockParent blockParent = newBlock.GetComponent<BlockParent>();
            blockParent.Owner = player;
            blockParent.Block = block;

            blockParent.Back.surfaceType = originalParent.Back.surfaceType;
            blockParent.Left.surfaceType = originalParent.Left.surfaceType;
            blockParent.Front.surfaceType = originalParent.Front.surfaceType;
            blockParent.Right.surfaceType = originalParent.Right.surfaceType;
            blockParent.Bottom.surfaceType = originalParent.Bottom.surfaceType;
            blockParent.Top.surfaceType = originalParent.Top.surfaceType;

            BlockLocations.Add(blockPosition, blockParent);

            if (placeType == BlockPlaceType.Local)
            {
                PlayerSerializer.Local?.DistributeBlock(true, block, blockPosition, blockEuler, blockScale);
            }

            return true;
        }

        public void RemoveBlock(Vector3 position, Player sender)
        {
            if (BlockLocations.TryGetValue(position, out BlockParent parent))
            {
                RemoveBlock(BlockLocations[position], sender);
            }
        }

        public void RemoveBlock(BlockParent parent, Player sender)
        {
            if (parent == null || parent.Owner.UserId != sender.UserId) return;

            BlockLocations.Remove(parent.transform.position);

            async void PlaySound_Destroy(IDataType currentPlaceSound)
            {
                AudioSource placeSource = parent.gameObject.GetOrAddComponent<AudioSource>();
                string currentSound = string.Concat("Dig_", currentPlaceSound.Name, UnityEngine.Random.Range(1, currentPlaceSound.MaxRange - 1));
                placeSource.spatialBlend = 1f;
                placeSource.clip = await AssetLoader.LoadAsset<AudioClip>(currentSound);
                placeSource.volume = currentPlaceSound.Volume / 4f;
                placeSource.pitch = currentPlaceSound.Pitch;
                placeSource.Play();
                Destroy(placeSource, 4);
            }

            if (sender.IsLocal)
            {
                PlayerSerializer.Local?.DistributeBlock(false, null, parent.transform.position, Vector3.zero, Vector3.zero);
            }

            PlaySound_Destroy(GetPlaceType(parent.Block.DestroySoundType));

            MeshRenderer _rendererObject = parent.transform.Find("Optimized Block").GetComponent<MeshRenderer>();
            Material[] _materialArray = _rendererObject.materials;

            GameObject particles = Instantiate(ParticleTemplate);
            particles.transform.position = parent.transform.position;

            for (int i = 0; i < _materialArray.Length; i++)
            {
                Material particleMaterial = new(_materialArray[i])
                {
                    mainTextureOffset = new Vector2(UnityEngine.Random.value, UnityEngine.Random.value),
                    mainTextureScale = Vector2.one / 6f
                };

                Transform particleObj = particles.transform.Find($"Particle ({i + 1})");

                ParticleSystemRenderer particleSystem = particleObj.GetComponent<ParticleSystemRenderer>();
                particleSystem.material = particleMaterial;

                particleObj.GetComponent<ParticleSystem>().Play();
            }

            Destroy(particles, 3);
            parent.Destroy();
        }

        public async void PlayTapSound(VRRig referenceRig, Type tapSoundType, bool isLeftHand)
        {
            IDataType currentFootType = GetFootstepType(tapSoundType);
            string currentSound = string.Concat("Step_", currentFootType.Name, UnityEngine.Random.Range(1, currentFootType.MaxRange - 1));
            var currentSource = isLeftHand ? referenceRig.leftHandPlayer : referenceRig.rightHandPlayer;

            currentSource.volume = currentFootType.Volume;
            currentSource.pitch = currentFootType.Pitch;
            currentSource.clip = await AssetLoader.LoadAsset<AudioClip>(currentSound);
            currentSource.PlayOneShot(currentSource.clip);
        }

        IDataType GetFootstepType(Type footstepType)
        {
            // Check to see if we already have a tap sound under this type
            if (FootstepSound_Cache.TryGetValue(footstepType, out IDataType cachedType)) return cachedType;

            var newStepType = Factory.Create(footstepType);
            FootstepSound_Cache.Add(footstepType, newStepType);
            return newStepType;
        }

        IDataType GetPlaceType(Type placeType)
        {
            // Check to see if we already have a place/remove sound under this type
            if (InteractionSound_Cache.TryGetValue(placeType, out var cachedType)) return cachedType;

            var newStepType = Factory.Create(placeType);
            InteractionSound_Cache.Add(placeType, newStepType);
            return newStepType;
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();

            foreach (KeyValuePair<Vector3, BlockParent> blockData in BlockLocations)
            {
                try
                {
                    blockData.Value?.Destroy();
                }
                catch
                {

                }
            }

            BlockLocations = new();
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);

            foreach (KeyValuePair<Vector3, BlockParent> blockData in BlockLocations.Where(data => data.Value.Owner == otherPlayer))
            {
                try
                {
                    blockData.Value?.Destroy();
                }
                catch
                {

                }
            }

            BlockLocations = BlockLocations.Where(data => data.Value != null).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
