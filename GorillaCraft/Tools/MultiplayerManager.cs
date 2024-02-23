using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace GorillaCraft.Tools
{
    public class MultiplayerManager
    {
        public const byte BlockInteractionCode = 130;
        public const byte SurfaceTapCode = 131;

        public static void BlockInteraction(bool isCreating, string block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale)
        {
            object[] content = new object[] { isCreating, block, blockPosition, blockEuler, blockScale };
            RaiseEventOptions raiseEventOptions = new()
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(BlockInteractionCode, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void SurfaceTap(string typeName, bool isLeftHand)
        {
            object[] content = new object[] { typeName, isLeftHand };
            RaiseEventOptions raiseEventOptions = new()
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(SurfaceTapCode, content, raiseEventOptions, SendOptions.SendReliable);
        }
    }
}
