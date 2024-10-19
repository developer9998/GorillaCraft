using GorillaCraft.Behaviours.Networking;
using HarmonyLib;
using UnityEngine;

namespace GorillaCraft.Patches
{
    [HarmonyPatch(typeof(RigContainer))]
    internal class RigAssignmentPatches
    {
        [HarmonyPatch("set_Creator"), HarmonyPostfix, HarmonyWrapSafe]
        public static void AddRigPatch(RigContainer __instance)
        {
            if (!__instance.Rig.GetComponent<GorillaCrafter>())
            {
                __instance.Rig.gameObject.AddComponent<GorillaCrafter>();
            }
        }

        [HarmonyPatch("OnDisable"), HarmonyPostfix, HarmonyWrapSafe]
        public static void RemoveRigPatch(RigContainer __instance)
        {
            if (__instance.Rig.TryGetComponent(out GorillaCrafter serializer))
            {
                Object.Destroy(serializer);
            }
        }
    }
}
