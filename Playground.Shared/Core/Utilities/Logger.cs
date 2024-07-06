using System;
using System.IO;

namespace Playground.Shared.Core.Utils;

public static class Logger
{
    private static StreamWriter _logStream;

    public static void Initialize(string logFilePath = "log.txt")
    {
        _logStream = new StreamWriter(logFilePath, true);
        _logStream.AutoFlush = true;

        Log("Logger initialized.");
    }

    public static void Log(string message)
    {
        string logMessage = $"{DateTime.Now}: {message}";

        Console.WriteLine(logMessage);
        _logStream.WriteLine(logMessage);
    }

    public static void LogError(string message)
    {
        string logMessage = $"{DateTime.Now}: ERROR: {message}";

        Console.WriteLine(logMessage);
        _logStream.WriteLine(logMessage);
    }

    public static void Close()
    {
        Log("Logger closed.");
        _logStream.Close();
    }
}