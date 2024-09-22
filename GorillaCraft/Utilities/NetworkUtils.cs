using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using GorillaCraft.Models;

namespace GorillaCraft.Utilities
{
    public class NetworkUtils
    {
        public static List<int> RequestingPlayers;

        // TODO: replace strings and vectors with byte arrays
        public static void BlockInteraction(bool isCreating, string block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale)
        {
            object[] content = [isCreating, block, blockPosition, blockEuler, blockScale];
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

        public static void SendBlocks(string[] blocks, Player targetPlayer)
        {
            object[] content = [blocks];
            RaiseEventOptions raiseEventOptions = new()
            {
                TargetActors = [targetPlayer.ActorNumber]
            };
            PhotonNetwork.RaiseEvent((int)GorillaCraftNetworkType.SendBlocksCode, content, raiseEventOptions, SendOptions.SendReliable);
        }

        public static bool IsBlockRequestValid(Player player)
        {
            if (RequestingPlayers.Contains(player.ActorNumber) || player.IsLocal) return false;
            RequestingPlayers.Add(player.ActorNumber);
            return true;
        }
    }
}
