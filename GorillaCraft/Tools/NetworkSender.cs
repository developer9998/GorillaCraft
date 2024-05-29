using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace GorillaCraft.Tools
{
    public class NetworkSender
    {
        public const byte BlockInteractionCode = 135;
        public const byte SurfaceTapCode = 131;
        public const byte RequestBlocksCode = 137;
        public const byte SendBlocksCode = 138;

        // TODO: replace strings and vectors with byte arrays
        public static void BlockInteraction(bool isCreating, string block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale)
        {
            object[] content = [isCreating, block, blockPosition, blockEuler, blockScale];
            RaiseEventOptions raiseEventOptions = new()
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(BlockInteractionCode, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void SurfaceTap(string typeName, bool isLeftHand)
        {
            object[] content = [typeName, isLeftHand];
            RaiseEventOptions raiseEventOptions = new()
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(SurfaceTapCode, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void RequestBlocks(Player targetPlayer)
        {
            object[] content = [PhotonNetwork.LocalPlayer];
            RaiseEventOptions raiseEventOptions = new()
            {
                TargetActors = [targetPlayer.ActorNumber]
            };
            PhotonNetwork.RaiseEvent(RequestBlocksCode, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void SendBlocks(string[] blocks, Player targetPlayer)
        {
            object[] content = [blocks];
            RaiseEventOptions raiseEventOptions = new()
            {
                TargetActors = [targetPlayer.ActorNumber]
            };
            PhotonNetwork.RaiseEvent(SendBlocksCode, content, raiseEventOptions, SendOptions.SendReliable);
        }
    }
}
