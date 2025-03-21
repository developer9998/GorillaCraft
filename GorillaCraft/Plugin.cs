using BepInEx;
using Bepinject;
using GorillaCraft.Models;
using HarmonyLib;
using Utilla.Attributes;

namespace GorillaCraft
{
    [BepInPlugin(Constants.GUID, Constants.Name, Constants.Version), BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [ModdedGamemode]
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
        public void OnModdedJoin()
        {
            Allowed.value = true;
        }

        [ModdedGamemodeLeave]
        public void OnModdedLeave()
        {
            Allowed.value = false;
        }
    }
}
