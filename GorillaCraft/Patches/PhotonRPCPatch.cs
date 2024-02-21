using GorillaCraft.Behaviours.Block;
using GorillaCraft.Behaviours.Networking;
using GorillaLocomotion;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace GorillaCraft.Patches
{
    [HarmonyPatch(typeof(PhotonView), nameof(PhotonView.RPC), new System.Type[] { typeof(string), typeof(RpcTarget), typeof(object[]) })]
    public class PhotonRPCPatch
    {
        private static BlockFace Face;

        public static bool Prefix(string methodName, PhotonView __instance, params object[] parameters)
        {
            if (methodName == "PlayHandTap" && __instance.IsMine)
            {
                bool isLeftHand = (bool)parameters[1];
                GorillaSurfaceOverride currentOverride = isLeftHand ? Player.Instance.leftHandSurfaceOverride : Player.Instance.rightHandSurfaceOverride;
                if (currentOverride != null && currentOverride.TryGetComponent(out Face))
                {
                    __instance.RPC(nameof(PlayerSerializer.PlaySurfaceType), RpcTarget.Others, Face.surfaceType.Name, isLeftHand);
                    return false;
                }
            }
            return true;
        }
    }
}
