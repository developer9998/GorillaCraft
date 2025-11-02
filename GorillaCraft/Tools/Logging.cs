using BepInEx.Logging;
using Bepinject;
using Zenject;

namespace GorillaCraft.Tools
{
    public class Logging : IInitializable
    {
        private static ManualLogSource Logger;

        public Logging(BepInLog log)
        {
            Logger = log.Logger;
        }

        public void Initialize()
        {

        }

        public static void Message(object data) => SendLog(LogLevel.Message, data);

        public static void Info(object data) => SendLog(LogLevel.Info, data);

        public static void Warning(object data) => SendLog(LogLevel.Warning, data);

        public static void Error(object data) => SendLog(LogLevel.Error, data);

        public static void Fatal(object data) => SendLog(LogLevel.Fatal, data);

        private static void SendLog(LogLevel logLevel, object data)
        {
#if DEBUG
            Logger?.Log(logLevel, data);
#endif
        }
    }
}
