using GorillaCraft.Behaviours.Block;
using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Blocks.Solid;
using GorillaCraft.Extensions;
using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using GorillaCraft.Tools;
using GorillaCraft.Utilities;
using HarmonyLib;
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
    /// <summary>
    /// BlockHandler is a component which operates the behaviour given to the initialization, calculations, creation, and removal of blocks.
    /// </summary>
    public class BlockHandler : MonoBehaviourPunCallbacks
    {
        private bool _initialized;

        private AssetLoader _assetLoader;
        private BlockDataFactory_PL _blockDataFactory;
        private Configuration _configuration;

        private List<IBlock> _blockList;

        private Dictionary<IBlock, GameObject> _blockCollection;
        private GameObject _solidBlockObject, _decorBlockObject, _spawnerBlockObject, _particleObject, _ladderObject, _stairObject;

        private Dictionary<Type, IDataType> _footstepCache, _interactionCache;

        private PhysicMaterial _slipperyPhysicMaterial;

        private Dictionary<Vector3, BlockObject> _blockLocationCollection;

        [Inject]
        public async void Construct(AssetLoader assetLoader, List<IBlock> blockList, BlockDataFactory_PL factory, Configuration config)
        {
            if (_initialized) return;
            _initialized = true;

            Plugin.Allowed.AddCallback(AllowStateChanged);

            _assetLoader = assetLoader;
            _blockDataFactory = factory;
            _configuration = config;

            _blockList = blockList;

            _slipperyPhysicMaterial = new PhysicMaterial
            {
                dynamicFriction = -0,
                staticFriction = -0,
                bounciness = 0,
                frictionCombine = PhysicMaterialCombine.Minimum,
                bounceCombine = PhysicMaterialCombine.Minimum
            };

            // Define lists, dictionaries, etc.
            _blockLocationCollection = [];
            _footstepCache = [];
            _interactionCache = [];
            _blockCollection = [];

            _solidBlockObject = await _assetLoader.LoadAsset<GameObject>(Constants.SolidBlockName);
            _decorBlockObject = await _assetLoader.LoadAsset<GameObject>(Constants.NonsolidBlockName);
            _spawnerBlockObject = await _assetLoader.LoadAsset<GameObject>(Constants.OtherDevBlockName);
            _ladderObject = await _assetLoader.LoadAsset<GameObject>(Constants.LadderBlockName);
            _particleObject = await _assetLoader.LoadAsset<GameObject>(Constants.ParticleName);
            _stairObject = await _assetLoader.LoadAsset<GameObject>(Constants.StaircaseName);

            async Task<BlockFace> Solid_PrepareSurface(GameObject currentObject, Material[] materialArray, string name, int materialIndex, BlockFaceInfo info, BlockObject _blockParent)
            {
                materialArray[materialIndex] = await _assetLoader.LoadAsset<Material>(info.FaceName);

                Transform relativeFace = currentObject.transform.Find("Collider/" + name);
                relativeFace.GetComponent<Collider>().material = (_blockParent.BlockType.GetType() == typeof(IceBlock) || _blockParent.BlockType.GetType() == typeof(PackedIceBlock)) ? _slipperyPhysicMaterial : relativeFace.GetComponent<Collider>().material;

                BlockFace blockFace = relativeFace.gameObject.AddComponent<BlockFace>();
                blockFace.Root = _blockParent;
                blockFace.SurfaceType = info.FaceSurfaceType;

                GorillaSurfaceOverride surface = relativeFace.gameObject.AddComponent<GorillaSurfaceOverride>();
                surface.overrideIndex = info.FaceSurfaceType == typeof(Surface_Snow) ? 32 : ((_blockParent.BlockType.GetType() == typeof(IceBlock) || _blockParent.BlockType.GetType() == typeof(PackedIceBlock)) ? 59 : 0);

                return blockFace;
            }

            BlockFace NonSolid_PrepareSurface(GameObject currentObject, string name, BlockObject blockParent, BlockFaceInfo info)
            {
                Transform relativeFace = currentObject.transform.Find("Collider/" + name);

                if (blockParent.BlockType.BlockForm != BlockForm.Ladder)
                {
                    relativeFace.gameObject.layer = 17;
                    relativeFace.parent.gameObject.layer = 17;
                }

                BlockFace blockFace = relativeFace.gameObject.AddComponent<BlockFace>();
                blockFace.Root = blockParent;
                blockFace.SurfaceType = info.FaceSurfaceType;

                return blockFace;
            }

            foreach (IBlock _currentBlock in _blockList)
            {
                GameObject _currentObject = null;

                try
                {
                    if (_currentBlock.BlockForm != BlockForm.Decoration && _currentBlock.BlockForm != BlockForm.Ladder && _currentBlock.BlockForm != BlockForm.StairsTest)
                    {
                        _currentObject = Instantiate(_currentBlock.BlockForm switch
                        {
                            BlockForm.DevSpawner => _spawnerBlockObject,
                            _ => _solidBlockObject
                        });

                        _assetLoader.SetObjectParent(_currentObject);

                        _currentObject.name = _currentBlock.BlockDefinition;
                        _currentObject.transform.localPosition = Vector3.zero;

                        MeshRenderer _rendererObject = _currentObject.transform.Find("Optimized Block").GetComponent<MeshRenderer>();
                        Material[] _materialArray = _rendererObject.materials;

                        BlockObject _blockParent = _currentObject.AddComponent<BlockObject>();
                        _blockParent.BlockType = _currentBlock;
                        _blockParent.Back = await Solid_PrepareSurface(_currentObject, _materialArray, "Back", 0, _currentBlock.Back, _blockParent);
                        _blockParent.Left = await Solid_PrepareSurface(_currentObject, _materialArray, "Left", 1, _currentBlock.Left, _blockParent);
                        _blockParent.Front = await Solid_PrepareSurface(_currentObject, _materialArray, "Front", 2, _currentBlock.Front, _blockParent);
                        _blockParent.Right = await Solid_PrepareSurface(_currentObject, _materialArray, "Right", 3, _currentBlock.Right, _blockParent);
                        _blockParent.Bottom = await Solid_PrepareSurface(_currentObject, _materialArray, "Bottom", 4, _currentBlock.Bottom, _blockParent);
                        _blockParent.Top = await Solid_PrepareSurface(_currentObject, _materialArray, "Top", 5, _currentBlock.Top, _blockParent);

                        _rendererObject.materials = _materialArray;
                    }
                    else if (_currentBlock.BlockForm == BlockForm.StairsTest)
                    {
                        _currentObject = Instantiate(_stairObject);

                        _assetLoader.SetObjectParent(_currentObject);

                        _currentObject.name = _currentBlock.BlockDefinition;
                        _currentObject.transform.localPosition = Vector3.zero;

                        MeshRenderer _rendererObject = _currentObject.transform.Find("StairBlock").GetComponent<MeshRenderer>();
                        Material _material = _rendererObject.material;

                        BlockObject _blockParent = _currentObject.AddComponent<BlockObject>();
                        _blockParent.BlockType = _currentBlock;

                        _material = await _assetLoader.LoadAsset<Material>(_currentBlock.Front.FaceName);

                        Transform blockPlayerCollider = _currentObject.transform.Find("BaseCollider");
                        Transform blockTotalCollider = _currentObject.transform.Find("TotalCollider");

                        blockTotalCollider.gameObject.layer = 19;

                        BlockFace blockFace = blockPlayerCollider.gameObject.AddComponent<BlockFace>();

                        blockFace.Root = _blockParent;
                        blockFace.SurfaceType = _currentBlock.Front.FaceSurfaceType;

                        GorillaSurfaceOverride surface = blockPlayerCollider.gameObject.AddComponent<GorillaSurfaceOverride>();
                        surface.overrideIndex = 0;

                        _rendererObject.material = _material;
                    }
                    else
                    {
                        _currentObject = Instantiate(_currentBlock.BlockForm switch
                        {
                            BlockForm.Ladder => _ladderObject,
                            _ => _decorBlockObject
                        });

                        _assetLoader.SetObjectParent(_currentObject);

                        _currentObject.name = _currentBlock.BlockDefinition;
                        _currentObject.transform.localPosition = Vector3.zero;

                        _currentObject.GetComponentInChildren<MeshRenderer>(true).material = await _assetLoader.LoadAsset<Material>(_currentBlock.Front.FaceName);

                        BlockObject _blockParent = _currentObject.AddComponent<BlockObject>();
                        _blockParent.BlockType = _currentBlock;
                        _blockParent.Back = NonSolid_PrepareSurface(_currentObject, "Back", _blockParent, _currentBlock.Back);

                        if (_currentBlock.BlockForm != BlockForm.Ladder)
                        {
                            _blockParent.Left = NonSolid_PrepareSurface(_currentObject, "Left", _blockParent, _currentBlock.Left);
                            _blockParent.Front = NonSolid_PrepareSurface(_currentObject, "Front", _blockParent, _currentBlock.Front);
                            _blockParent.Right = NonSolid_PrepareSurface(_currentObject, "Right", _blockParent, _currentBlock.Right);
                            _blockParent.Bottom = NonSolid_PrepareSurface(_currentObject, "Bottom", _blockParent, _currentBlock.Bottom);
                            _blockParent.Top = NonSolid_PrepareSurface(_currentObject, "Top", _blockParent, _currentBlock.Top);
                        }
                        else
                        {
                            _currentObject.transform.Find("Collider/Back").gameObject.GetOrAddComponent<Ladder>();
                        }
                    }
                }
                catch (Exception exception)
                {
                    Logging.Log(exception.String(), BepInEx.Logging.LogLevel.Error);
                }

                _blockCollection.Add(_currentBlock, _currentObject);
                _currentObject.SetActive(false);
            }
        }

        public bool PlacementAllowed(string block, RaycastHit hit) => PlacementAllowed(_blockList.First(a => a.GetType().Name == block), hit);

        public bool PlacementAllowed(IBlock block, RaycastHit hit)
        {
            if (block.BlockForm == BlockForm.Ladder && hit.collider)
            {
                if (hit.collider.TryGetComponent(out BlockFace face))
                {
                    BlockObject parent = face.Root;
                    return parent.BlockType.BlockForm != BlockForm.Ladder && parent.BlockType.BlockForm != BlockForm.StairsTest && (parent.Left == face || parent.Front == face || parent.Right == face || parent.Back == face);
                }
                return false;
            }
            return true;
        }

        public bool PlaceBlock(BlockPlaceType placeType, string block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale, Player player, out BlockObject blockParent, BlockInclusions inclusions) => PlaceBlock(placeType, _blockList.First(a => a.GetType().Name == block), blockPosition, blockEuler, blockScale, player, out blockParent, inclusions);

        private bool PlaceBlock(BlockPlaceType placeType, IBlock block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale, Player player, out BlockObject blockParent, BlockInclusions inclusions = BlockInclusions.Audio)
        {
            // Run a check if any player with the mod would be suffocated / trapped by this block
            if (placeType == BlockPlaceType.Local)
            {
                Bounds bounds = new(blockPosition, blockScale);

                VRRig LocalRig = GorillaTagger.Instance.offlineVRRig;
                SphereCollider headCollider = LocalRig.headMesh.transform.Find("SpeakerHeadCollider").GetComponent<SphereCollider>();
                CapsuleCollider bodyCollider = LocalRig.headMesh.transform.parent.Find("BodyTrigger").GetComponent<CapsuleCollider>();

                if (bounds.Intersects(headCollider.bounds) || bounds.Intersects(bodyCollider.bounds))
                {
                    blockParent = null;
                    return false;
                }

                foreach (RaycastHit hit in Physics.SphereCastAll(blockPosition, blockScale.x, blockPosition, 0f))
                {
                    if (hit.collider.name == "SpeakerHeadCollider" || hit.collider.name == "BodyTrigger")
                    {
                        blockParent = null;
                        return false;
                    }
                }
            }

            // Run a check if there is already an existing block at this point
            if (_blockLocationCollection.ContainsKey(blockPosition))
            {
                blockParent = null;
                return false;
            }

            // Run a check if a "base-block" exists for this block type / interface
            if (!_blockCollection.TryGetValue(block, out GameObject baseBlock))
            {
                blockParent = null;
                return false;
            }
            BlockObject originalParent = baseBlock.GetComponent<BlockObject>();

            GameObject newBlock = Instantiate(baseBlock);
            newBlock.SetActive(true);
            newBlock.transform.position = blockPosition;
            newBlock.transform.localScale = blockScale;

            if (block.BlockForm == BlockForm.Solid && player.UserId != "2ECA9EBDE7C7C6B7")
            {
                Transform optimizedBlock = newBlock.transform.Find("Optimized Block");
                optimizedBlock.eulerAngles = blockEuler;
                optimizedBlock.Rotate(new Vector3(-90, 0, 0), Space.Self);
            }
            else
            {
                newBlock.transform.eulerAngles = blockEuler;
            }

            if (inclusions.HasFlag(BlockInclusions.Audio)) BlockAudioUtils.PlaySound(_assetLoader, newBlock, GetInteractionType(block.PlaceSoundType), _configuration.PlaceBreakVolume.Value / 100f);

            blockParent = newBlock.GetOrAddComponent<BlockObject>();
            blockParent.Owner = player;
            blockParent.BlockType = block;

            if (block.BlockForm != BlockForm.Decoration)
            {
                blockParent.Back.SurfaceType = originalParent.Back.SurfaceType;

                if (block.BlockForm != BlockForm.Ladder)
                {
                    blockParent.Left.SurfaceType = originalParent.Left.SurfaceType;
                    blockParent.Front.SurfaceType = originalParent.Front.SurfaceType;
                    blockParent.Right.SurfaceType = originalParent.Right.SurfaceType;
                    blockParent.Bottom.SurfaceType = originalParent.Bottom.SurfaceType;
                    blockParent.Top.SurfaceType = originalParent.Top.SurfaceType;
                }

                if (block.BlockForm == BlockForm.DevSpawner)
                {

                }
            }

            _blockLocationCollection.Add(blockPosition, blockParent);
            if (placeType == BlockPlaceType.Local)
            {
                PlayerSerializer.Local?.DistributeBlock(true, block, blockPosition, blockEuler, blockScale);
            }

            return true;
        }

        public void RemoveBlock(Vector3 position, Player sender)
        {
            if (_blockLocationCollection.ContainsKey(position))
            {
                RemoveBlock(_blockLocationCollection[position], sender);
            }
        }

        public void RemoveBlock(BlockObject parent, Player sender, BlockInclusions inclusions = BlockInclusions.Audio | BlockInclusions.Particles)
        {
            //bool networkBreakFactor = parent.Owner.UserId == sender.UserId;
            bool networkBreakFactor = true;
            if (parent == null || !networkBreakFactor) return;

            _blockLocationCollection.Remove(parent.transform.position);

            if (sender.IsLocal) // only network the removal of this block if it's local to our client
            {
                PlayerSerializer.Local?.DistributeBlock(false, null, parent.transform.position, Vector3.zero, Vector3.zero);
            }

            if (parent.ChildrenBlocks.Any()) // remove any children connected to this block, local client or not
            {
                List<BlockObject> list = new(parent.ChildrenBlocks);
                list.ForEach(child =>
                {
                    Logging.Log($"Remove child attempt at [{child.transform.position.x}, {child.transform.position.y}, {child.transform.position.z}");
                    RemoveBlock(child, child.Owner);
                });
            }

            if (inclusions.HasFlag(BlockInclusions.Audio))
            {
                BlockAudioUtils.PlaySound(_assetLoader, parent.gameObject, GetInteractionType(parent.BlockType.DestroySoundType), _configuration.PlaceBreakVolume.Value / 100f);
            }

            if (inclusions.HasFlag(BlockInclusions.Particles) && parent.BlockType.BlockForm != BlockForm.Decoration && parent.BlockType.BlockForm != BlockForm.Ladder)
            {
                MeshRenderer _rendererObject = parent.transform.Find("Optimized Block").GetComponent<MeshRenderer>();
                Material[] _materialArray = _rendererObject.materials;

                GameObject particles = Instantiate(_particleObject);
                particles.transform.position = parent.transform.position;

                for (int i = 0; i < _materialArray.Length; i++)
                {
                    Material particleMaterial = new(_materialArray[i]);
                    particleMaterial.SetVector("_TileOffset", new Vector4(1f / 6f, 1f / 6f, UnityEngine.Random.value, UnityEngine.Random.value));

                    Transform particleObj = particles.transform.Find($"Particle ({i + 1})");

                    ParticleSystem.MainModule main = particleObj.GetComponent<ParticleSystem>().main;
                    main.gravityModifierMultiplier *= parent.transform.localScale.y;
                    particleObj.transform.localScale *= parent.transform.localScale.y;

                    ParticleSystemRenderer particleSystem = particleObj.GetComponent<ParticleSystemRenderer>();
                    particleSystem.material = particleMaterial;

                    particleObj.GetComponent<ParticleSystem>().Play();
                }

                Destroy(particles, 3);
            }
            else if (inclusions.HasFlag(BlockInclusions.Particles))
            {
                Material baseMat = parent.transform.Find(parent.BlockType.BlockForm != BlockForm.Ladder ? "MinecraftDecorSample" : "LadderSurface").GetComponent<MeshRenderer>().material;

                GameObject particles = Instantiate(_particleObject);
                particles.transform.position = parent.transform.position;

                for (int i = 0; i < 6; i++)
                {
                    Material particleMaterial = new(baseMat);
                    particleMaterial.SetVector("_TileOffset", new Vector4(1f / 6f, 1f / 6f, UnityEngine.Random.value, UnityEngine.Random.value));

                    Transform particleObj = particles.transform.Find($"Particle ({i + 1})");

                    ParticleSystem.MainModule main = particleObj.GetComponent<ParticleSystem>().main;
                    main.gravityModifierMultiplier *= parent.transform.localScale.y;
                    particleObj.transform.localScale *= parent.transform.localScale.y;

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
            string currentSound = string.Concat("Step_", currentFootType.Name, UnityEngine.Random.Range(1, currentFootType.MaxRange));
            var currentSource = isLeftHand ? referenceRig.leftHandPlayer : referenceRig.rightHandPlayer;

            currentSource.volume = currentFootType.Volume * (_configuration.FootstepVolume.Value / 100f);
            currentSource.pitch = currentFootType.Pitch;
            currentSource.clip = await _assetLoader.LoadAsset<AudioClip>(currentSound);
            currentSource.PlayOneShot(currentSource.clip);
        }

        IDataType GetFootstepType(Type footstepType)
        {
            // Check to see if we already have a tap sound under this type
            if (_footstepCache.TryGetValue(footstepType, out IDataType cachedType)) return cachedType;

            var newStepType = _blockDataFactory.Create(footstepType);
            _footstepCache.Add(footstepType, newStepType);
            return newStepType;
        }

        IDataType GetInteractionType(Type placeType)
        {
            // Check to see if we already have a place/remove sound under this type
            if (_interactionCache.TryGetValue(placeType, out var cachedType)) return cachedType;

            var newStepType = _blockDataFactory.Create(placeType);
            _interactionCache.Add(placeType, newStepType);
            return newStepType;
        }

        private void AllowStateChanged(bool state)
        {
            if (!state && NetworkSystem.Instance.InRoom) OnLeftRoom();
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();

            _blockLocationCollection.Where(data => data.Value != null).Do(data => DestroyImmediate(data.Value.gameObject));
            _blockLocationCollection.Clear();
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);

            var affectedBlocks = _blockLocationCollection.Where(data => data.Value.Owner == otherPlayer);
            var looseBlocks = _blockLocationCollection.Except(affectedBlocks).Where(data => data.Value.ParentalBlocks.Any() && data.Value.ParentalBlocks.Count == 1 && data.Value.ParentalBlocks.First().Owner == otherPlayer);

            _blockLocationCollection = _blockLocationCollection.Except(affectedBlocks.Concat(looseBlocks)).ToDictionary(x => x.Key, x => x.Value);
            affectedBlocks.Do(data => DestroyImmediate(data.Value.gameObject));
            looseBlocks.Do(data =>
            {
                if (data.Value.IsLocal)
                {
                    RemoveBlock(data.Value, data.Value.Owner, BlockInclusions.None);
                }
                else
                {
                    data.Value.Destroy();
                }
            });
        }
    }
}
