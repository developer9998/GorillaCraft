using GorillaCraft.Behaviours.Block;
using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Blocks.Solid;
using GorillaCraft.Extensions;
using GorillaCraft.Factories;
using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using GorillaCraft.Utilities;
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
        private GameObject SolidTemplate, NonsolidTemplate, OtherDevTemplate, ParticleTemplate;

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

            SolidTemplate = await AssetLoader.LoadAsset<GameObject>(Constants.SolidBlockName);
            NonsolidTemplate = await AssetLoader.LoadAsset<GameObject>(Constants.NonsolidBlockName);
            OtherDevTemplate = await AssetLoader.LoadAsset<GameObject>(Constants.OtherDevBlockName);
            ParticleTemplate = await AssetLoader.LoadAsset<GameObject>(Constants.ParticleName);

            async Task<BlockFace> Solid_PrepareSurface(GameObject currentObject, Material[] materialArray, string name, int materialIndex, BlockFaceInfo info, BlockParent _blockParent)
            {
                materialArray[materialIndex] = await AssetLoader.LoadAsset<Material>(info.FaceName);

                Transform relativeFace = currentObject.transform.Find("Collider/" + name);
                relativeFace.GetComponent<Collider>().material = _blockParent.Block.GetType() == typeof(IceBlock) ? Slippery : relativeFace.GetComponent<Collider>().material;

                BlockFace blockFace = relativeFace.gameObject.AddComponent<BlockFace>();
                blockFace.baseBlock = _blockParent;
                blockFace.surfaceType = info.FaceSurfaceType;

                GorillaSurfaceOverride surface = relativeFace.gameObject.AddComponent<GorillaSurfaceOverride>();
                surface.overrideIndex = info.FaceSurfaceType == typeof(Surface_Snow) ? 32 : (_blockParent.Block.GetType() == typeof(IceBlock) ? 59 : 0);

                return blockFace;
            }

            BlockFace NonSolid_PrepareSurface(GameObject currentObject, string name, BlockParent blockParent)
            {
                Transform relativeFace = currentObject.transform.Find("Collider/" + name);
                relativeFace.gameObject.layer = 19;
                relativeFace.parent.gameObject.layer = 19;

                BlockFace blockFace = relativeFace.gameObject.AddComponent<BlockFace>();
                blockFace.baseBlock = blockParent;

                return blockFace;
            }

            foreach (IBlock _currentBlock in BlockList)
            {
                GameObject _currentObject = null;
                if (_currentBlock.BlockForm != BlockForm.Nonsolid)
                {
                    _currentObject = Instantiate(_currentBlock.BlockForm switch
                    {
                        BlockForm.Solid_OtherDev => OtherDevTemplate,
                        _ => SolidTemplate
                    });

                    _currentObject.name = _currentBlock.BlockDefinition;
                    _currentObject.transform.localPosition = Vector3.zero;

                    MeshRenderer _rendererObject = _currentObject.transform.Find("Optimized Block").GetComponent<MeshRenderer>();
                    Material[] _materialArray = _rendererObject.materials;

                    BlockParent _blockParent = _currentObject.AddComponent<BlockParent>();
                    _blockParent.Block = _currentBlock;
                    _blockParent.Back = await Solid_PrepareSurface(_currentObject, _materialArray, "Back", 0, _currentBlock.Back, _blockParent);
                    _blockParent.Left = await Solid_PrepareSurface(_currentObject, _materialArray, "Left", 1, _currentBlock.Left, _blockParent);
                    _blockParent.Front = await Solid_PrepareSurface(_currentObject, _materialArray, "Front", 2, _currentBlock.Front, _blockParent);
                    _blockParent.Right = await Solid_PrepareSurface(_currentObject, _materialArray, "Right", 3, _currentBlock.Right, _blockParent);
                    _blockParent.Bottom = await Solid_PrepareSurface(_currentObject, _materialArray, "Bottom", 4, _currentBlock.Down, _blockParent);
                    _blockParent.Top = await Solid_PrepareSurface(_currentObject, _materialArray, "Top", 5, _currentBlock.Up, _blockParent);

                    _rendererObject.materials = _materialArray;
                }
                else
                {
                    _currentObject = Instantiate(NonsolidTemplate);

                    _currentObject.name = _currentBlock.BlockDefinition;
                    _currentObject.transform.localPosition = Vector3.zero;

                    _currentObject.transform.Find("MinecraftDecorSample").GetComponent<MeshRenderer>().material = await AssetLoader.LoadAsset<Material>(_currentBlock.Front.FaceName);

                    BlockParent _blockParent = _currentObject.AddComponent<BlockParent>();
                    _blockParent.Back = NonSolid_PrepareSurface(_currentObject, "Back", _blockParent);
                    _blockParent.Left = NonSolid_PrepareSurface(_currentObject, "Left", _blockParent);
                    _blockParent.Front = NonSolid_PrepareSurface(_currentObject, "Front", _blockParent);
                    _blockParent.Right = NonSolid_PrepareSurface(_currentObject, "Right", _blockParent);
                    _blockParent.Bottom = NonSolid_PrepareSurface(_currentObject, "Bottom", _blockParent);
                    _blockParent.Top = NonSolid_PrepareSurface(_currentObject, "Top", _blockParent);
                }

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

            if (placeType != BlockPlaceType.Recovery) BlockAudioUtils.PlaySound(AssetLoader, newBlock, GetInteractionType(block.PlaceSoundType));

            BlockParent blockParent = newBlock.GetOrAddComponent<BlockParent>();
            blockParent.Owner = player;
            blockParent.Block = block;

            if (block.BlockForm != BlockForm.Nonsolid)
            {
                blockParent.Back.surfaceType = originalParent.Back.surfaceType;
                blockParent.Left.surfaceType = originalParent.Left.surfaceType;
                blockParent.Front.surfaceType = originalParent.Front.surfaceType;
                blockParent.Right.surfaceType = originalParent.Right.surfaceType;
                blockParent.Bottom.surfaceType = originalParent.Bottom.surfaceType;
                blockParent.Top.surfaceType = originalParent.Top.surfaceType;
            }

            BlockLocations.Add(blockPosition, blockParent);
            if (placeType == BlockPlaceType.Local) PlayerSerializer.Local?.DistributeBlock(true, block, blockPosition, blockEuler, blockScale);

            return true;
        }

        public void RemoveBlock(Vector3 position, Player sender)
        {
            if (BlockLocations.ContainsKey(position))
            {
                RemoveBlock(BlockLocations[position], sender);
            }
        }

        public void RemoveBlock(BlockParent parent, Player sender)
        {
            if (parent == null || parent.Owner.UserId != sender.UserId) return;

            BlockLocations.Remove(parent.transform.position);

            if (sender.IsLocal)
            {
                PlayerSerializer.Local?.DistributeBlock(false, null, parent.transform.position, Vector3.zero, Vector3.zero);
            }

            BlockAudioUtils.PlaySound(AssetLoader, parent.gameObject, GetInteractionType(parent.Block.DestroySoundType));

            if (parent.Block.BlockForm != BlockForm.Nonsolid)
            {
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
            }
            else
            {
                Material baseMat = parent.transform.Find("MinecraftDecorSample").GetComponent<MeshRenderer>().material;

                GameObject particles = Instantiate(ParticleTemplate);
                particles.transform.position = parent.transform.position;

                for (int i = 0; i < 6; i++)
                {
                    Material particleMaterial = new(baseMat)
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
            }
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

        IDataType GetInteractionType(Type placeType)
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
