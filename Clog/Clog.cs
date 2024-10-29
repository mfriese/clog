using System;

namespace Ox
{
    public class Clog
{
    public enum LogLevel
    {
        Trace, Debug, Info, Warning, Error, Critical, None
    }

    public static void Critical(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        => Invoke(LogLevel.Critical, message, memberName, sourceFilePath, sourceLineNumber);

    public static void Error(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        => Invoke(LogLevel.Error, message, memberName, sourceFilePath, sourceLineNumber);

    public static void Warning(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        => Invoke(LogLevel.Warning, message, memberName, sourceFilePath, sourceLineNumber);

    public static void Info(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        => Invoke(LogLevel.Info, message, memberName, sourceFilePath, sourceLineNumber);

    public static void Debug(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        => Invoke(LogLevel.Debug, message, memberName, sourceFilePath, sourceLineNumber);

    public static void Trace(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        => Invoke(LogLevel.Trace, message, memberName, sourceFilePath, sourceLineNumber);

    protected static void Invoke(
        LogLevel level,
        string msg,
        string memberName,
        string sourceFilePath,
        int sourceLineNumber)
    {
        var sourceFileName = Path.GetFileName(sourceFilePath);
        var logLevel = $"[{LogLevelStrings[(int)level]}]";
        var logDetails = $"{sourceFileName}/{memberName}():{sourceLineNumber}";
        var logMessage = $"> {DateTime.Now:s}: {msg}";
        var oldColors = (Console.ForegroundColor, Console.BackgroundColor);
        (Console.ForegroundColor, Console.BackgroundColor) = (LogLevelForeColors[(int)level], LogLevelBackColors[(int)level]);
        Console.Write(logLevel);
        (Console.ForegroundColor, Console.BackgroundColor) = oldColors;
        Console.WriteLine(logDetails);
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
}
