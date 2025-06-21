using GorillaCraft.Behaviours;
using GorillaCraft.Behaviours.Block;
using GorillaLocomotion;
using HarmonyLib;

namespace GorillaCraft.Patches
{
    [HarmonyPatch(typeof(VRRig), nameof(VRRig.SetHandEffectData))]
    public class LocalHandTapRPC
    {
        private static BlockFace _currentFace;

        public static bool Prefix(VRRig __instance, object effectContext, bool isLeftHand)
        {
            if (!__instance.isOfflineVRRig) return true;

            GorillaSurfaceOverride currentOverride = isLeftHand ? GTPlayer.Instance.leftHandSurfaceOverride : GTPlayer.Instance.rightHandSurfaceOverride;
            if (currentOverride && currentOverride.TryGetComponent(out _currentFace))
            {
                Traverse.Create(effectContext).Field("soundFX").SetValue(null);
                GTPlayer.Instance.GetComponent<BlockHandler>().PlayTapSound(__instance, _currentFace.SurfaceType, isLeftHand);
                return false;
            }

            return true;
        }
    }
}
