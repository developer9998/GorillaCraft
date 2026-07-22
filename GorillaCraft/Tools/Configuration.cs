using BepInEx.Configuration;

namespace GorillaCraft.Tools;

public class Configuration
{
    public ConfigEntry<bool> DarkMode;
    public ConfigEntry<int> PlaceBreakVolume, FootstepVolume;

    public Configuration(ConfigFile file)
    {
        DarkMode = file.Bind("Appearance", "Dark Mode", false, "Whether the build menu should use a dark colour scheme");
        PlaceBreakVolume = file.Bind("Auditory", "Place/Break Volume", 100, "The volume given to audio for placing/breaking a block");
        FootstepVolume = file.Bind("Auditory", "Footstep Volume", 100, "The volume given to audio for stepping on a block");
    }
}
