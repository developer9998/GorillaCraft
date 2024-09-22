using GorillaCraft.Behaviours.Block;
using GorillaCraft.Utilities;
using GorillaLocomotion;
using HarmonyLib;
using Photon.Pun;

namespace GorillaCraft.Patches
{
    [HarmonyPatch(typeof(PhotonView), nameof(PhotonView.RPC), [typeof(string), typeof(RpcTarget), typeof(object[])])]
    public class RPCHandTapPatch
    {
        private static BlockFace _currentFace;

        public static bool Prefix(string methodName, PhotonView __instance, params object[] parameters)
        {
            if (methodName == "OnHandTapRPC" && __instance.IsMine)
            {
                bool isLeftHand = (bool)parameters[1];

                GorillaSurfaceOverride currentOverride = isLeftHand ? Player.Instance.leftHandSurfaceOverride : Player.Instance.rightHandSurfaceOverride;
                if (currentOverride && currentOverride.TryGetComponent(out _currentFace))
                {
                    NetworkUtils.SurfaceTap(_currentFace.SurfaceType.Name, isLeftHand);
                    return false;
                }
            }
            return true;
        }
    }
}
