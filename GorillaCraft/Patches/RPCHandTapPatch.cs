﻿using GorillaCraft.Behaviours.Block;
using GorillaCraft.Utilities;
using GorillaLocomotion;
using HarmonyLib;
using Photon.Pun;
using System.Linq;

namespace GorillaCraft.Patches
{
    [HarmonyPatch(typeof(PhotonView), nameof(PhotonView.RPC), [typeof(string), typeof(RpcTarget), typeof(object[])])]
    public class RPCHandTapPatch
    {
        private static BlockFace _currentFace;

        public static bool Prefix(string methodName, PhotonView __instance, params object[] parameters)
        {
            if (methodName == "OnHandTapRPC" && __instance.IsMine && parameters.ElementAtOrDefault(2) is bool isLeftHand)
            {
                GorillaSurfaceOverride currentOverride = isLeftHand ? GTPlayer.Instance.leftHandSurfaceOverride : GTPlayer.Instance.rightHandSurfaceOverride;
                if (currentOverride && currentOverride.TryGetComponent(out _currentFace))
                {
                    NetworkUtils.SurfaceTap(_currentFace.SurfaceType.FullName, isLeftHand);
                    return false;
                }
            }
            return true;
        }
    }
}
