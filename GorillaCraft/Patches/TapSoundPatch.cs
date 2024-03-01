using GorillaCraft.Behaviours;
using GorillaCraft.Behaviours.Block;
using GorillaLocomotion;
using HarmonyLib;

namespace GorillaCraft.Patches
{
    [HarmonyPatch(typeof(VRRig), "PlayHandTapLocal")]
    public class TapSoundPatch
    {
        private static BlockFace _currentFace;

        public static bool Prefix(VRRig __instance, bool isLeftHand)
        {
            if (!__instance.isOfflineVRRig) return true;

            var currentOverride = isLeftHand ? Player.Instance.leftHandSurfaceOverride : Player.Instance.rightHandSurfaceOverride;
            if (currentOverride != null && currentOverride.TryGetComponent(out _currentFace))
            {
                Player.Instance.GetComponent<BlockHandler>().PlayTapSound(__instance, _currentFace.SurfaceType, isLeftHand);
                return false;
            }

            return true;
        }
    }
}
