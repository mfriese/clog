using System;

public class Clog
{
    public enum LogLevel
    {
        Trace,
        Debug,
        Info,
        Warning,
        Error,
        Critical,
        None
    }

    public static void Critical(string message) => Invoke(LogLevel.Critical, message);
    public static void Error(string message) => Invoke(LogLevel.Error, message);
    public static void Warning(string message) => Invoke(LogLevel.Warning, message);
    public static void Info(string message) => Invoke(LogLevel.Info, message);
    public static void Debug(string message) => Invoke(LogLevel.Debug, message);
    public static void Trace(string message) => Invoke(LogLevel.Trace, message);

    protected static void Invoke(LogLevel level, string msg)
    {
        int levelIndex = (int)level;

        var logLevel = $"[{LogLevelStrings[levelIndex]}]";
        var logMessage = $" {DateTime.Now:s}: {msg}";
        var oldColors = (Console.ForegroundColor, Console.BackgroundColor);
        (Console.ForegroundColor, Console.BackgroundColor) = (LogLevelForeColors[levelIndex], LogLevelBackColors[levelIndex]);
        Console.Write(logLevel);

        (Console.ForegroundColor, Console.BackgroundColor) = oldColors;
        Console.WriteLine(logMessage);
    }

    private static readonly string[] LogLevelStrings = new[]
    {
        "TRCE",
        "DBUG",
        "INFO",
        "WARN",
        "FAIL",
        "CRIT"
    };

    private static readonly ConsoleColor[] LogLevelForeColors = new[]
    {
        ConsoleColor.Black,
        ConsoleColor.White,
        ConsoleColor.Green,
        ConsoleColor.Yellow,
        ConsoleColor.White,
        ConsoleColor.White
    };

    private static readonly ConsoleColor[] LogLevelBackColors = new[]
    {
        ConsoleColor.White,
        ConsoleColor.Black,
        ConsoleColor.Black,
        ConsoleColor.Black,
        ConsoleColor.DarkRed,
        ConsoleColor.Magenta
    };
}
