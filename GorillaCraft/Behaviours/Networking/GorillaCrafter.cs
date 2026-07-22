using GorillaCraft.Behaviours.Blocks;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using GorillaCraft.Utilities;
using GorillaLibrary.Extensions;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GorillaCraft.Behaviours.Networking;

[DisallowMultipleComponent, RequireComponent(typeof(RigContainer))]
public class GorillaCrafter : MonoBehaviourPunCallbacks, IPhotonViewCallback
{
    public static GorillaCrafter Local { get; private set; }
    public VRRig Rig => _rigContainer.Rig;
    public Player Creator => _player;
    public bool IsPunished => _isPunished;

    public readonly Dictionary<Guid, Block> Blocks = [];

    private RigContainer _rigContainer;

    private Player _player;

    private bool _isPunished;

    private int _strikes;

    private float _strikeTimer;

    public void Start()
    {
        _rigContainer = GetComponent<RigContainer>();
        _player = _rigContainer.Creator.GetPlayerRef();

        if (Local == null && Creator.IsLocal)
        {
            Local = this;
            MainScript.Instance.AddUser(Creator);
            return;
        }

        if (Local != this && Creator.IsLocal)
        {
            Destroy(this);
            return;
        }

        NetworkUtility.RequestBlocks(Creator);
    }

    public void Update()
    {
        if (_strikes == 0 && _strikeTimer == 0) return;

        _strikeTimer = Mathf.Max(_strikeTimer - Time.unscaledDeltaTime, 0f);
        if (_strikeTimer == 0)
        {
            _strikeTimer = Constants.PunishmentCooldown;
            _strikes--;
        }
    }

    public void AddBlock(Block block) => ManageBlock(true, block);

    public void RemoveBlock(Block block) => ManageBlock(false, block);

    private void ManageBlock(bool isCreating, Block block)
    {
        try
        {
            Guid serialNumber = block.SerialNumber;

            if (isCreating)
            {
                if (Blocks.ContainsKey(serialNumber)) return;
                Blocks.Add(serialNumber, block);

                if (Creator.IsLocal)
                {
                    byte faceIndex = 0;
                    if (block.ParentalBlock.IsObjectExistent() && block.ParentalBlock.FindChildFace(block) is BlockFace face && face.IsObjectExistent()) faceIndex = block.ParentalBlock.GetIndex(face);

                    long blockPosition = Utils.PackVector3ToLong(block.Position);
                    long blockEulerAngles = Utils.PackVector3ToLong(block.EulerAngles);
                    NetworkUtility.BlockInteraction_Place(block.Reference.BlockId, serialNumber, block.ParentalBlock.IsObjectExistent() ? block.ParentalBlock.SerialNumber : null, faceIndex, blockPosition, blockEulerAngles, block.Size);
                }

                return;
            }

            if (Blocks.TryGetValue(serialNumber, out var lookupBlock))
            {
                Blocks.Remove(serialNumber);

                if (Creator.IsLocal)
                {
                    NetworkUtility.BlockInteraction_Destroy(serialNumber);
                }
            }
        }
        catch (Exception ex)
        {
            Logging.Error($"{nameof(ManageBlock)} threw an exception {ex}");
        }
    }

    public void Punish(BlockStrikePurpose strikePurpose)
    {
        if (_isPunished) return;

        _strikes++;
        _strikeTimer = Constants.PunishmentCooldown;

        Logging.Warning($"{Creator} has recieved Strike #{_strikes} per {strikePurpose}");

        if (_strikes >= Constants.PunishmentTotal)
        {
            _isPunished = true;
            RemoveUser();
        }
    }

    public void Remove()
    {
        if (!enabled) return;
        enabled = false;

        if (Local == this) Local = null;

        RemoveUser();
        Destroy(this);
    }

    public void RemoveUser()
    {
        var blocks = Blocks.Values.ToArray();

        for (int i = 0; i < blocks.Length; i++)
        {
            var block = blocks.ElementAtOrDefault(i);
            block?.Destroy(useDestroyEffects: false);
        }

        MainScript.Instance.RemoveUser(Creator);
    }
}
