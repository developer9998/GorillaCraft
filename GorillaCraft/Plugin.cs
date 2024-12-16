using BepInEx;
using Bepinject;
using GorillaCraft.Models;
using HarmonyLib;

namespace GorillaCraft
{
    [BepInPlugin(Constants.GUID, Constants.Name, Constants.Version), BepInDependency("dev.tillahook", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Watchable<bool> Allowed { get; private set; }

        public async void Awake()
        {
            Allowed = new Watchable<bool>();

            Zenjector.Install<MainInstaller>().OnProject().WithConfig(Config).WithLog(Logger);

            Harmony.CreateAndPatchAll(typeof(Plugin).Assembly, Constants.GUID);

            TillaHook.TillaHook.OnModdedJoin += (string gameMode) => Allowed.value = true;
            TillaHook.TillaHook.OnModdedLeave += (string gameMode) => Allowed.value = false;
        }
    }
}
