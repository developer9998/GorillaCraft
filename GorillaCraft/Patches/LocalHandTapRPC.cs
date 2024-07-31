using GorillaCraft.Behaviours;
using GorillaCraft.Behaviours.Block;
using GorillaLocomotion;
using HarmonyLib;

namespace GorillaCraft.Patches
{
    [HarmonyPatch(typeof(VRRig), "OnHandTap")]
    public class LocalHandTapRPC
    {
        private static BlockFace _currentFace;

        public static bool Prefix(VRRig __instance, bool isLeftHand)
        {
            if (!__instance.isOfflineVRRig) return true;

            GorillaSurfaceOverride currentOverride = isLeftHand ? Player.Instance.leftHandSurfaceOverride : Player.Instance.rightHandSurfaceOverride;
            if (currentOverride && currentOverride.TryGetComponent(out _currentFace))
            {
                Player.Instance.GetComponent<BlockHandler>().PlayTapSound(__instance, _currentFace.SurfaceType, isLeftHand);
                return false;
            }

            return true;
        }
    }
}
