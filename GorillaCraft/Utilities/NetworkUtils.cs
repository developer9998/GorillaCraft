using ExitGames.Client.Photon;
using GorillaCraft.Models;
using Photon.Pun;
using Photon.Realtime;

namespace GorillaCraft.Utilities
{
    public class NetworkUtils
    {
        public static void BlockInteraction(params object[] content)
        {
            // object[] content = [isCreating, block, blockPosition, blockEuler, blockScale];
            RaiseEventOptions raiseEventOptions = new()
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent((int)GorillaCraftNetworkType.BlockInteractionCode, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void SurfaceTap(string typeName, bool isLeftHand)
        {
            object[] content = [typeName, isLeftHand];
            RaiseEventOptions raiseEventOptions = new()
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent((int)GorillaCraftNetworkType.SurfaceTapCode, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void RequestBlocks(Player targetPlayer)
        {
            object[] content = [PhotonNetwork.LocalPlayer];
            RaiseEventOptions raiseEventOptions = new()
            {
                TargetActors = [targetPlayer.ActorNumber]
            };
            PhotonNetwork.RaiseEvent((int)GorillaCraftNetworkType.RequestBlocksCode, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void SendBlocks(object[] blocks, Player targetPlayer)
        {
            object[] content = [blocks];
            RaiseEventOptions raiseEventOptions = new()
            {
                TargetActors = [targetPlayer.ActorNumber]
            };
            PhotonNetwork.RaiseEvent((int)GorillaCraftNetworkType.SendBlocksCode, content, raiseEventOptions, SendOptions.SendReliable);
        }
    }
}
