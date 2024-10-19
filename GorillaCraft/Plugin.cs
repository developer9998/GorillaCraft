using BepInEx;
using Bepinject;
using GorillaCraft.Models;
using HarmonyLib;
using Utilla;

namespace GorillaCraft
{
    [ModdedGamemode, BepInPlugin(Constants.GUID, Constants.Name, Constants.Version), BepInIncompatibility("dev.devminecraftinternal"), BepInIncompatibility("org.iidk.gorillatag.iimenu")]
    public class Plugin : BaseUnityPlugin
    {
        public static Watchable<bool> Allowed { get; private set; }

        public async void Awake()
        {
            Allowed = new Watchable<bool>();

            Zenjector.Install<MainInstaller>().OnProject().WithConfig(Config).WithLog(Logger);

            Harmony.CreateAndPatchAll(typeof(Plugin).Assembly, Constants.GUID);
        }

        [ModdedGamemodeJoin]
        public async void OnJoin()
        {
            Allowed.value = true;
        }

        [ModdedGamemodeLeave]
        public async void OnLeave()
        {
            Allowed.value = false;
        }
    }
}
