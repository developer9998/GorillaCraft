using BepInEx.Logging;
using Bepinject;
using Zenject;

namespace GorillaCraft.Tools
{
    public class Logging : IInitializable
    {
        private static ManualLogSource LogSource;

        public Logging(BepInLog log)
        {
            LogSource = log.Logger;
        }

        public void Initialize()
        {
            Log("Logging for GorillaCraft has been initialized successfully!", LogLevel.Info);
        }

        public static void Log(object data, LogLevel level = LogLevel.Info)
        {
#if DEBUG
            LogSource ??= Logger.CreateLogSource(Constants.Name);
            LogSource.Log(level, data);
#endif
        }
    }
}
