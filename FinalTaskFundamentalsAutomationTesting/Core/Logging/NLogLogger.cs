using NLog;

namespace FinalTaskFundamentalsAutomationTesting.Core.Logging;

public class NLogLogger : ILogger
{
    private readonly Logger _logger;

    public NLogLogger(Type type)
    {
        _logger = LogManager.GetLogger(type.FullName ?? "NA");
    }

    public void LogInfo(string message) => _logger.Info(message);
    public void LogWarning(string message) => _logger.Warn(message);
    public void LogError(string message) => _logger.Error(message);
    public void LogDebug(string message) => _logger.Debug(message);
}
