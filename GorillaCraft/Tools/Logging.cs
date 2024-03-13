using BepInEx.Logging;
using Bepinject;
using GorillaCraft.Extensions;
using System.Diagnostics;
using System.Reflection;
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
            Log("i love you kaylie! -dane", LogLevel.Info);
        }

        public static void Log(object data, LogLevel level = LogLevel.Info)
        {
            MethodBase methodInfo = new StackTrace().GetFrame(1).GetMethod();
            LogSource.Log(level, string.Concat(methodInfo.String(), data));
        }
    }
}
