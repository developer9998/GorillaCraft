using GorillaCraft.Behaviours;
using GorillaCraft.Behaviours.Blocks;
using GorillaLocomotion;
using HarmonyLib;

namespace GorillaCraft.Patches;

[HarmonyPatch(typeof(VRRig), nameof(VRRig.SetHandEffectData))]
public class LocalHandTapRPC
{
    private static BlockFace _currentFace;

    public static bool Prefix(VRRig __instance, HandEffectContext effectContext, bool isLeftHand)
    {
        if (!__instance.isOfflineVRRig) return true;

        GorillaSurfaceOverride currentOverride = (isLeftHand ? GTPlayer.Instance.leftHand : GTPlayer.Instance.rightHand).surfaceOverride;
        if (currentOverride && currentOverride.TryGetComponent(out _currentFace))
        {
            effectContext.soundFX = null;
            MainScript.BlockScript.PlayTapSound(__instance, _currentFace.FaceObject.TapSound, isLeftHand);
            return false;
        }

        return true;
    }
}
