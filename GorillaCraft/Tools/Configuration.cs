using BepInEx.Configuration;
using Bepinject;

namespace GorillaCraft.Tools
{
    public class Configuration
    {
        private readonly ConfigFile ConfigFile;

        public ConfigEntry<bool> DarkMode;
        public ConfigEntry<int> PlaceBreakVolume, FootstepVolume;

        public Configuration(BepInConfig config)
        {
            ConfigFile = config.Config;

            DarkMode = ConfigFile.Bind("Appearance", "Dark Mode", false, "Whether the build menu should use a dark colour scheme");
            PlaceBreakVolume = ConfigFile.Bind("Auditory", "Place/Break Volume", 100, "The volume given to audio for placing/breaking a block");
            FootstepVolume = ConfigFile.Bind("Auditory", "Footstep Volume", 100, "The volume given to audio for stepping on a block");
        }
    }
}
