using GorillaCraft.Behaviours.Block;
using GorillaCraft.Tools;
using GorillaLocomotion;
using HarmonyLib;
using Photon.Pun;
using System;

namespace GorillaCraft.Patches
{
    [HarmonyPatch(typeof(PhotonView), nameof(PhotonView.RPC), new Type[] { typeof(string), typeof(RpcTarget), typeof(object[]) })]
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
                    MultiplayerManager.SurfaceTap(Face.SurfaceType.Name, isLeftHand);
                    return false;
                }
            }
            return true;
        }
    }
}
