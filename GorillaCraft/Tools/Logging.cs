using BepInEx.Logging;

namespace GorillaCraft.Tools;

public static class Logging
{
    public static ManualLogSource Logger;

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
