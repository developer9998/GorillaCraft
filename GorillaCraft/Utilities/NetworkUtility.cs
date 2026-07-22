using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GorillaCraft.Utilities;

public class NetworkUtility
{
    public const byte EventCode = 176;

    public static readonly int Id_BlockInteraction = StaticHash.Compute("GorillaCraft1009".GetStaticHash(), "BlockInteraction".GetStaticHash());

    public static readonly int Id_SurfaceTap = StaticHash.Compute("GorillaCraft1009".GetStaticHash(), "SurfaceTap".GetStaticHash());

    public static readonly int Id_RequestBlocks = StaticHash.Compute("GorillaCraft1009".GetStaticHash(), "RequestBlocks".GetStaticHash());

    public static readonly int Id_SendBlocks = StaticHash.Compute("GorillaCraft1009".GetStaticHash(), "SendBlocks".GetStaticHash());

    public static void BlockInteraction_Place(short block, Guid instanceId, Guid? parentId, byte parentFace, long position, long rotation, float scale)
    {
        BlockInteraction(true, block, instanceId.ToString(), parentId != null ? parentId.ToString() : 0, parentFace, position, rotation, scale);
    }

    public static void BlockInteraction_Destroy(Guid guid)
    {
        BlockInteraction(false, guid.ToString());
    }

    private static void BlockInteraction(params object[] content)
    {
        RaiseEventOptions raiseEventOptions = new()
        {
            Receivers = ReceiverGroup.Others
        };
        PhotonNetwork.RaiseEvent(EventCode, new object[1] { Id_BlockInteraction }.Concat(content).ToArray(), raiseEventOptions, SendOptions.SendReliable);
    }

    public static void SurfaceTap(byte soundId, bool isLeftHand)
    {
        object[] content = [Id_SurfaceTap, soundId, isLeftHand];
        RaiseEventOptions raiseEventOptions = new()
        {
            Receivers = ReceiverGroup.Others
        };
        PhotonNetwork.RaiseEvent(EventCode, content, raiseEventOptions, SendOptions.SendReliable);
    }

    public static void RequestBlocks(Player targetPlayer)
    {
        object[] content = [Id_RequestBlocks, PhotonNetwork.LocalPlayer];
        RaiseEventOptions raiseEventOptions = new()
        {
            TargetActors = [targetPlayer.ActorNumber]
        };
        PhotonNetwork.RaiseEvent(EventCode, content, raiseEventOptions, SendOptions.SendReliable);
    }

    public static void SendBlocks(Player targetPlayer, List<object[]> blocks)
    {
        List<object> content = [Id_SendBlocks];
        blocks.ForEach(array => content.Add(array));
        RaiseEventOptions raiseEventOptions = new()
        {
            TargetActors = [targetPlayer.ActorNumber]
        };
        PhotonNetwork.RaiseEvent(EventCode, content.ToArray(), raiseEventOptions, SendOptions.SendReliable);
    }
}
