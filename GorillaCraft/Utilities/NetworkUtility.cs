using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

namespace GorillaCraft.Utilities
{
    public class NetworkUtility
    {
        public const byte EventCode = 176;

        public static readonly int Id_BlockInteraction = StaticHash.Compute(Constants.Name.GetStaticHash(), "BlockInteraction".GetStaticHash());

        public static readonly int Id_SurfaceTap = StaticHash.Compute(Constants.Name.GetStaticHash(), "SurfaceTap".GetStaticHash());

        public static readonly int Id_RequestBlocks = StaticHash.Compute(Constants.Name.GetStaticHash(), "RequestBlocks".GetStaticHash());

        public static readonly int Id_SendBlocks = StaticHash.Compute(Constants.Name.GetStaticHash(), "SendBlocks".GetStaticHash());

        public static void BlockInteraction(params object[] content)
        {
            // object[] content = [isCreating, block, blockPosition, blockEuler, blockScale];
            RaiseEventOptions raiseEventOptions = new()
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(EventCode, new object[1] { Id_BlockInteraction }.Concat(content).ToArray(), raiseEventOptions, SendOptions.SendReliable);
        }

        public static void SurfaceTap(string typeName, bool isLeftHand)
        {
            object[] content = [Id_SurfaceTap, typeName, isLeftHand];
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

        public static void SendBlocks(object[] blocks, Player targetPlayer)
        {
            object[] content = [Id_SendBlocks, blocks];
            RaiseEventOptions raiseEventOptions = new()
            {
                TargetActors = [targetPlayer.ActorNumber]
            };
            PhotonNetwork.RaiseEvent(EventCode, content, raiseEventOptions, SendOptions.SendReliable);
        }
    }
}
