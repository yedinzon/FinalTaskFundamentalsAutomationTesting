using NLog;
using NLog.Config;
using NLog.Targets;

namespace FinalTaskFundamentalsAutomationTesting.Core.Logging;

public static class NLogSetup
{
    /// <summary>
    /// Log directory path.
    /// </summary>
    private static readonly string LogDirectory = "logs";

    /// <summary>
    /// Log file name pattern.
    /// </summary>
    private static readonly string LogFileNamePattern = "test_execution_${shortdate}_${threadid}.log";

    /// <summary>
    /// Layout pattern for log messages.
    /// </summary>
    private static readonly string Layout = "${longdate} | ${uppercase:${level}} | ${logger} | ${message} ${exception:format=toString}";

    /// <summary>
    /// File target name.
    /// </summary>
    private static readonly string FileTarget = "logfile";

    /// <summary>
    /// Console target name.
    /// </summary>
    private static readonly string ConsoleTarget = "logconsole";

    /// <summary>
    /// Configures NLog with file and console targets.
    /// </summary>
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
