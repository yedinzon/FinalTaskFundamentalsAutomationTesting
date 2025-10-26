using NLog;
using NLog.Config;
using NLog.Targets;

namespace FinalTaskFundamentalsAutomationTesting.Core.Logging;

public static class NLogSetup
{
    private static readonly string LogDirectory = "logs";
    private static readonly string LogFileNamePattern = "test_execution_${shortdate}_${threadid}.log";
    private static readonly string Layout = "${longdate} | ${uppercase:${level}} | ${logger} | ${message} ${exception:format=toString}";
    private static readonly string FileTarget = "logfile";
    private static readonly string ConsoleTarget = "logconsole";
    public static void Configure()
    {
        Directory.CreateDirectory(LogDirectory);
        var config = new LoggingConfiguration();

        var logfile = new FileTarget(FileTarget)
        {
            FileName = Path.Combine(LogDirectory, LogFileNamePattern),
            Layout = Layout,
            KeepFileOpen = false
        };

        var logconsole = new ConsoleTarget(ConsoleTarget)
        {
            Layout = Layout
        };

        config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
        config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);

        LogManager.Configuration = config;
    }
}
