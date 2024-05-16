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

        }

        public static void Log(object data, LogLevel level = LogLevel.Info)
        {
#if DEBUG
            LogSource.Log(level, data);
#endif
        }
    }
}
