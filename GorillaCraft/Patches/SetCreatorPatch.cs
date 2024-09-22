using GorillaCraft.Behaviours.Networking;
using HarmonyLib;

namespace GorillaCraft.Patches
{
    [HarmonyPatch(typeof(RigContainer), "set_Creator")]
    internal class SetCreatorPatch
    {
        [HarmonyWrapSafe]
        public static void Postfix(RigContainer __instance)
        {
            var networkView = __instance.Rig;
            networkView.gameObject.AddComponent<PlayerSerializer>();
        }
    }
}
