using NLog;
using NLog.Config;
using NLog.Targets;

namespace FinalTaskFundamentalsAutomationTesting.Core.Logging;

public static class NLogSetup
{
    public static void Configure()
    {
        var config = new LoggingConfiguration();
        string logDir = "logs";
        var layout = "${longdate} | ${uppercase:${level}} | ${logger} | ${message} ${exception:format=toString}";
        string logFileName = Path.Combine(logDir, $"test_execution_${{shortdate}}_${{threadid}}.log");
        Directory.CreateDirectory(logDir);

        var logfile = new FileTarget("fileTarget")
        {
            FileName = logFileName,
            Layout = layout,
            KeepFileOpen = false
        };

        var logconsole = new ConsoleTarget("logconsole")
        {
            Layout = layout
        };

        config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
        config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);

        LogManager.Configuration = config;
    }
}
