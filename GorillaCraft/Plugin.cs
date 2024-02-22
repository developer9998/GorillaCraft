using BepInEx;
using Bepinject;
using GorillaCraft.Patches;
using HarmonyLib;
using System;
using System.Reflection;
using Utilla;

namespace GorillaCraft
{
    [ModdedGamemode, BepInPlugin(Constants.GUID, Constants.Name, Constants.Version), BepInIncompatibility("dev.devminecraftinternal")]
    public class Plugin : BaseUnityPlugin
    {
        public static bool InRoom;
        public static event Action<bool> RoomChanged;

        Assembly GTAssembly => typeof(GorillaTagger).Assembly;
        Type RigPatchType => typeof(RigPatches);

        public void Awake()
        {
            Zenjector.Install<MainInstaller>().OnProject().WithConfig(Config).WithLog(Logger);

            Harmony harmony = new(Constants.GUID);
            harmony.PatchAll(typeof(Plugin).Assembly);

            Type rigCacheType = GTAssembly.GetType("VRRigCache");
            harmony.Patch(AccessTools.Method(rigCacheType, "AddRigToGorillaParent"), postfix: new HarmonyMethod(RigPatchType, nameof(RigPatches.AddPatch)));
            harmony.Patch(AccessTools.Method(rigCacheType, "RemoveRigFromGorillaParent"), postfix: new HarmonyMethod(RigPatchType, nameof(RigPatches.RemovePatch)));
        }

        [ModdedGamemodeJoin]
        public void OnJoin()
        {
            InRoom = true;
            RoomChanged?.Invoke(true);
        }

        [ModdedGamemodeLeave]
        public void OnLeave()
        {
            InRoom = false;
            RoomChanged?.Invoke(false);
        }
    }
}
