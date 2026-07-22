using BepInEx;
using GorillaCraft.Behaviours.Blocks;
using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Extensions;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using GorillaCraft.Utilities;
using GorillaLibrary.Extensions;
using GorillaLibrary.Models;
using GorillaLibrary.Utilities;
using GorillaLocomotion;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Block = GorillaCraft.Behaviours.Blocks.Block;

namespace GorillaCraft.Behaviours;

public class BlockScript : MonoBehaviourPunCallbacks
{
    public AssetLoaderSync AssetLoader;

    public Configuration Config;

    public BlockContainerObject BlockContainer;

    private bool _initialized;

    private Dictionary<long, bool> _blockPositions;

    private Dictionary<BlockObject, GameObject> _blockReferences;

    private Dictionary<short, BlockObject> _blockIdTranslation;

    private GameObject _solidBlockObject, _decorBlockObject, _spawnerBlockObject, _particleObject, _ladderObject, _stairObject;

    public void Start()
    {
        if (_initialized) return;
        _initialized = true;

        _blockIdTranslation = [];

        foreach (var block in BlockContainer.Blocks)
        {
            if (_blockIdTranslation.ContainsKey(block.BlockId))
            {
                Logging.Error($"Block #{block.BlockId} already exists: {_blockIdTranslation[block.BlockId]}");
                Logging.Error($"Attempting to add {block.Definition}");
                continue;
            }

            _blockIdTranslation.Add(block.BlockId, block);
        }

        _blockIdTranslation = BlockContainer.Blocks.ToDictionary(block => block.BlockId, block => block);

        // Define lists, dictionaries, etc.
        _blockPositions = [];
        _blockReferences = [];

        _solidBlockObject = AssetLoader.LoadAsset<GameObject>(Constants.SolidBlockName);
        _decorBlockObject = AssetLoader.LoadAsset<GameObject>(Constants.NonsolidBlockName);
        _spawnerBlockObject = AssetLoader.LoadAsset<GameObject>(Constants.OtherDevBlockName);
        _ladderObject = AssetLoader.LoadAsset<GameObject>(Constants.LadderBlockName);
        _particleObject = AssetLoader.LoadAsset<GameObject>(Constants.ParticleName);
        _stairObject = AssetLoader.LoadAsset<GameObject>(Constants.StaircaseName);

        BlockFace Solid_PrepareSurface(GameObject currentObject, Material[] materialArray, string name, int materialIndex, BlockFaceObject info, Block _blockParent)
        {
            materialArray[materialIndex] = info.Material;

            Transform relativeFace = currentObject.transform.Find("Collider/" + name);
            relativeFace.GetComponent<Collider>().material = info.PhysicMaterial ?? relativeFace.GetComponent<Collider>().material;

            BlockFace blockFace = relativeFace.gameObject.AddComponent<BlockFace>();
            blockFace.Root = _blockParent;
            blockFace.FaceObject = info;

            // 0: default
            // 59: iceground
            // 147: Snowman

            GorillaSurfaceOverride surface = relativeFace.gameObject.AddComponent<GorillaSurfaceOverride>();
            surface.overrideIndex = info.SurfaceOverride == -1 ? 0 : info.SurfaceOverride;

            return blockFace;
        }

        BlockFace NonSolid_PrepareSurface(GameObject currentObject, string name, Block blockParent, BlockFaceObject info)
        {
            Transform relativeFace = currentObject.transform.Find("Collider/" + name);

            if (blockParent.Reference.Form != BlockForm.Ladder)
            {
                relativeFace.gameObject.layer = 17;
                relativeFace.parent.gameObject.layer = 17;
            }

            BlockFace blockFace = relativeFace.gameObject.AddComponent<BlockFace>();
            blockFace.Root = blockParent;
            blockFace.FaceObject = info;

            return blockFace;
        }

        foreach (BlockObject _currentBlock in BlockContainer.Blocks)
        {
            GameObject _currentObject = null;

            try
            {
                if (_currentBlock.Form != BlockForm.Decoration && _currentBlock.Form != BlockForm.Ladder && _currentBlock.Form != BlockForm.StairsTest)
                {
                    _currentObject = Instantiate(_currentBlock.Form switch
                    {
                        BlockForm.DevSpawner => _spawnerBlockObject,
                        _ => _solidBlockObject
                    });

                    _currentObject.name = _currentBlock.Definition;
                    _currentObject.transform.parent = transform;
                    _currentObject.transform.localPosition = Vector3.zero;

                    MeshRenderer _rendererObject = _currentObject.transform.Find("Optimized Block").GetComponent<MeshRenderer>();
                    Material[] _materialArray = _rendererObject.materials;

                    Block _blockParent = _currentObject.AddComponent<Block>();
                    _blockParent.Reference = _currentBlock;
                    _blockParent.Back = Solid_PrepareSurface(_currentObject, _materialArray, "Back", 0, _currentBlock.Back ?? _currentBlock.Base, _blockParent);
                    _blockParent.Left = Solid_PrepareSurface(_currentObject, _materialArray, "Left", 1, _currentBlock.Left ?? _currentBlock.Base, _blockParent);
                    _blockParent.Front = Solid_PrepareSurface(_currentObject, _materialArray, "Front", 2, _currentBlock.Front ?? _currentBlock.Base, _blockParent);
                    _blockParent.Right = Solid_PrepareSurface(_currentObject, _materialArray, "Right", 3, _currentBlock.Right ?? _currentBlock.Base, _blockParent);
                    _blockParent.Bottom = Solid_PrepareSurface(_currentObject, _materialArray, "Bottom", 4, _currentBlock.Bottom ?? _currentBlock.Base, _blockParent);
                    _blockParent.Top = Solid_PrepareSurface(_currentObject, _materialArray, "Top", 5, _currentBlock.Top ?? _currentBlock.Base, _blockParent);

                    _rendererObject.materials = _materialArray;
                }
                else if (_currentBlock.Form == BlockForm.StairsTest) // didn't work out :<
                {
                    _currentObject = Instantiate(_stairObject);

                    _currentObject.name = _currentBlock.Definition;
                    _currentObject.transform.parent = transform;
                    _currentObject.transform.localPosition = Vector3.zero;

                    MeshRenderer _rendererObject = _currentObject.transform.Find("StairBlock").GetComponent<MeshRenderer>();
                    Material _material = _rendererObject.material;

                    Block _blockParent = _currentObject.AddComponent<Block>();
                    _blockParent.Reference = _currentBlock;

                    _material = _currentBlock.Front.Material;

                    Transform blockPlayerCollider = _currentObject.transform.Find("BaseCollider");
                    Transform blockTotalCollider = _currentObject.transform.Find("TotalCollider");

                    blockTotalCollider.gameObject.layer = 19;

                    BlockFace blockFace = blockPlayerCollider.gameObject.AddComponent<BlockFace>();

                    blockFace.Root = _blockParent;
                    blockFace.FaceObject = _currentBlock.Front;

                    GorillaSurfaceOverride surface = blockPlayerCollider.gameObject.AddComponent<GorillaSurfaceOverride>();
                    surface.overrideIndex = 0;

                    _rendererObject.material = _material;
                }
                else
                {
                    _currentObject = Instantiate(_currentBlock.Form switch
                    {
                        BlockForm.Ladder => _ladderObject,
                        _ => _decorBlockObject
                    });

                    _currentObject.name = _currentBlock.Definition;
                    _currentObject.transform.parent = transform;
                    _currentObject.transform.localPosition = Vector3.zero;

                    _currentObject.GetComponentInChildren<MeshRenderer>(true).material = _currentBlock.Front.Material;

                    Block _blockParent = _currentObject.AddComponent<Block>();
                    _blockParent.Reference = _currentBlock;
                    _blockParent.Back = NonSolid_PrepareSurface(_currentObject, "Back", _blockParent, _currentBlock.Back);

                    if (_currentBlock.Form != BlockForm.Ladder)
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
                Logging.Info(exception);
            }

            _blockReferences.Add(_currentBlock, _currentObject);
            _currentObject.SetActive(false);
        }
    }

    public bool PlacementAllowed(BlockObject block, Vector3 position, RaycastHit hit)
    {
        if (HasPosition(position)) return false;

        if (block.Form == BlockForm.Ladder && hit.collider)
        {
            if (hit.collider.TryGetComponent(out BlockFace face))
            {
                Block parent = face.Root;
                return face.ChildBlocks.Count == 0 && parent.Reference.Form != BlockForm.Ladder && parent.Reference.Form != BlockForm.StairsTest && (parent.Left == face || parent.Front == face || parent.Right == face || parent.Back == face);
            }
            return false;
        }

        return true;
    }

    public bool PlaceBlock(BlockPlaceType placeType, short blockId, Guid guid, Vector3 blockPosition, Vector3 blockEuler, float blockScaleFactor, NetPlayer player, out Block blockParent, BlockInclusions inclusions)
    {
        if (!_blockIdTranslation.TryGetValue(blockId, out BlockObject block))
        {
            blockParent = null;
            return false;
        }

        return PlaceBlock(placeType, block: block, guid, blockPosition, blockEuler, blockScaleFactor, player, out blockParent, inclusions);
    }

    public bool PlaceBlock(BlockPlaceType placeType, BlockObject block, Guid guid, Vector3 blockPosition, Vector3 blockEuler, float blockScaleFactor, NetPlayer sender, out Block blockParent, BlockInclusions inclusions = BlockInclusions.Audio)
    {
        Vector3 blockScale = Vector3.one * blockScaleFactor;

        VRRig rig = RigUtility.GetRig(sender)?.Rig;

        GorillaCrafter crafter;
        GameObject baseBlock;

        try
        {
            if (rig.IsObjectNull() || !rig.TryGetComponent(out crafter))
            {
                throw new NullReferenceException($"PlaceBlock: player {sender.GetName(false)} does not exist");
            }

            if (!_blockReferences.TryGetValue(block, out baseBlock))
            {
                throw new NullReferenceException($"PlaceBlock: block reference for {block.name} does not exist");
            }

            if (placeType != BlockPlaceType.Server)
            {
                Quaternion checkRotation = Quaternion.Euler(blockEuler);
                float diameter = GTPlayer.Instance.headCollider.radius * 2.1f;
                Vector3 checkSize = blockScale + (Vector3.one * diameter);

                foreach (var (player, behaviour) in MainScript.Instance.Players)
                {
                    if (behaviour.Rig.RigWithinArea(blockPosition, checkRotation, checkSize))
                    {
                        if (placeType == BlockPlaceType.Server) crafter.Punish(BlockStrikePurpose.ObstructingPlayer);

                        throw new InvalidOperationException($"Player {player} is obstructing block - {placeType}");
                    }
                }

                foreach (var friendCollider in FindObjectsByType<GorillaFriendCollider>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
                {
                    if (friendCollider.PointWithinFriendCollider(blockPosition))
                    {
                        if (placeType == BlockPlaceType.Server) crafter.Punish(BlockStrikePurpose.ObstructingScene);
                        blockParent = null;
                        return false;
                    }
                }

                foreach (var proximity in FindObjectsByType<CosmeticWardrobeProximityDetector>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
                {
                    if (proximity.PointWithinProximity(blockPosition))
                    {
                        if (placeType == BlockPlaceType.Server) crafter.Punish(BlockStrikePurpose.ObstructingScene);
                        blockParent = null;
                        return false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logging.Error(ex);
            blockParent = null;
            return false;
        }

        try
        {
            Block originalParent = baseBlock.GetComponent<Block>();

            GameObject newBlock = Instantiate(baseBlock);
            newBlock.SetActive(true);
            newBlock.transform.parent = transform;
            newBlock.transform.position = blockPosition;
            newBlock.transform.localScale = blockScale;

            if (block.Form == BlockForm.Solid)
            {
                Transform optimizedBlock = newBlock.transform.Find("Optimized Block");
                optimizedBlock.eulerAngles = blockEuler;
                optimizedBlock.Rotate(new Vector3(-90, 0, 0), Space.Self);
            }
            else
            {
                newBlock.transform.eulerAngles = blockEuler;
            }

            if (inclusions.HasFlag(BlockInclusions.Audio)) SoundUtility.PlaySound(newBlock, block.PlaceSound, Config.PlaceBreakVolume.Value / 100f);

            var returnedBlock = newBlock.GetOrAddComponent<Block>();
            returnedBlock.Owner = sender;
            returnedBlock.Reference = block;
            returnedBlock.SerialNumber = guid;
            returnedBlock.Position = blockPosition;
            returnedBlock.EulerAngles = blockEuler;
            returnedBlock.Size = blockScaleFactor;

            if (block.Form != BlockForm.Decoration)
            {
                returnedBlock.Back.FaceObject = originalParent.Back.FaceObject;

                if (block.Form != BlockForm.Ladder)
                {
                    returnedBlock.Left.FaceObject = originalParent.Left.FaceObject;
                    returnedBlock.Front.FaceObject = originalParent.Front.FaceObject;
                    returnedBlock.Right.FaceObject = originalParent.Right.FaceObject;
                    returnedBlock.Bottom.FaceObject = originalParent.Bottom.FaceObject;
                    returnedBlock.Top.FaceObject = originalParent.Top.FaceObject;
                }
            }

            blockParent = returnedBlock;
            ThreadingHelper.Instance.StartSyncInvoke(() => crafter.AddBlock(returnedBlock));

            return true;
        }
        catch (Exception ex)
        {
            Logging.Fatal($"{block.Definition} #{block.BlockId}");
            Logging.Error(ex);
        }

        blockParent = null;

        return false;
    }

    public bool TryFindBlock(NetPlayer player, Guid guid, out Block block)
    {
        if (RigUtility.TryGetRig(player, out RigContainer playerRig) && playerRig.TryGetComponent(out GorillaCrafter crafter) && crafter.Blocks.TryGetValue(guid, out Block foundBlock))
        {
            block = foundBlock;
            return true;
        }

        block = null;
        return false;
    }

    public bool TryFindBlock(Guid guid, out Block block)
    {
        if (NetworkSystem.Instance.InRoom)
        {
            foreach (NetPlayer player in NetworkSystem.Instance.AllNetPlayers)
            {
                if (TryFindBlock(player, guid, out Block foundBlock))
                {
                    block = foundBlock;
                    return true;
                }
            }

            block = null;
            return false;
        }

        if (TryFindBlock(NetworkSystem.Instance.GetLocalPlayer(), guid, out Block localBlock))
        {
            block = localBlock;
            return true;
        }

        block = null;
        return false;
    }

    public void RemoveBlock(Guid guid, NetPlayer sender)
    {
        if (TryFindBlock(sender, guid, out Block block))
        {
            RemoveBlock(block, sender);
            return;
        }

        Logging.Warning("Tried to remove block by serial number that could not be found");
    }

    public void RemoveBlock(Block parent, NetPlayer sender, BlockInclusions inclusions = BlockInclusions.Audio)
    {
        bool networkBreakFactor = parent.Owner.ActorNumber == sender.ActorNumber;
        if (parent == null || !networkBreakFactor) return;

        VRRig rig = GorillaGameManager.StaticFindRigForPlayer(sender);

        if (!rig || !rig.TryGetComponent(out GorillaCrafter crafter))
        {
            Logging.Warning($"Player {sender.NickName} is missing their Crafter title");
            return;
        }

        crafter.RemoveBlock(parent);

        try
        {
            void CheckFace(BlockFace face)
            {
                if (face.IsObjectNull() || face.ChildBlocks.Count == 0) return;

                var clone = face.ChildBlocks.ToArray();
                clone.ForEach(child => RemoveBlock(child, child.Owner));
            }

            CheckFace(parent.Front);
            CheckFace(parent.Left);
            CheckFace(parent.Right);
            CheckFace(parent.Back);
            CheckFace(parent.Top);
            CheckFace(parent.Bottom);

            if (inclusions.HasFlag(BlockInclusions.Audio))
            {
                SoundUtility.PlaySound(parent.gameObject, parent.Reference.BreakSound, Config.PlaceBreakVolume.Value / 100f);
            }

            if (inclusions.HasFlag(BlockInclusions.Particles) && parent.Reference.Form != BlockForm.Decoration && parent.Reference.Form != BlockForm.Ladder)
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
                Material baseMat = parent.transform.Find(parent.Reference.Form != BlockForm.Ladder ? "MinecraftDecorSample" : "LadderSurface").GetComponent<MeshRenderer>().material;

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
        catch (Exception ex)
        {
            Logging.Error(ex);
        }
    }

    public async void PlayTapSound(VRRig referenceRig, BlockSoundObject blockSound, bool isLeftHand)
    {
        var currentSource = isLeftHand ? referenceRig.leftHandPlayer : referenceRig.rightHandPlayer;
        currentSource.volume = blockSound.Volume * (Config.FootstepVolume.Value / 100f);
        currentSource.pitch = blockSound.Pitch;
        currentSource.clip = blockSound.Audio[UnityEngine.Random.Range(0, blockSound.Audio.Length)];
        currentSource.PlayOneShot(currentSource.clip);
    }

    public bool HasPosition(Vector3 vector) => HasPosition(Utils.PackVector3ToLong(vector));

    public bool HasPosition(long packed) => _blockPositions.ContainsKey(packed);

    public void AddPosition(Vector3 vector, bool isLocal) => AddPosition(Utils.PackVector3ToLong(vector), isLocal);

    public void AddPosition(long packed, bool isLocal)
    {
        if (_blockPositions.ContainsKey(packed)) return;
        _blockPositions.Add(packed, isLocal);
    }

    public void RemovePosition(Vector3 vector) => RemovePosition(Utils.PackVector3ToLong(vector));

    public void RemovePosition(long packed)
    {
        if (!_blockPositions.ContainsKey(packed)) return;
        _blockPositions.Remove(packed);
    }

#if DEBUG

    public void PlaceEveryBlock()
    {
        for (int i = 0; i < _blockReferences.Count; i++)
        {
            PlaceBlock(BlockPlaceType.Local, _blockReferences.Keys.ElementAt(i), Guid.NewGuid(), Vector3.right * (i * 1.5f), Vector3.zero, 1f, NetworkSystem.Instance.GetLocalPlayer(), out _, BlockInclusions.None);
        }
    }

#endif
}
