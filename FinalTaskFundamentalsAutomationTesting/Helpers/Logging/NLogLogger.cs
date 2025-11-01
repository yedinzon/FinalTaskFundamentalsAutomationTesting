using NLog;

namespace FinalTaskFundamentalsAutomationTesting.Helpers.Logging;

/// <summary>
/// Provides an implementation of <see cref="ILogger"/> using NLog as the logging framework.
/// </summary>
/// <remarks>
/// This class automatically configures NLog when first used and provides methods
/// to log messages at different severity levels: Debug, Info, Warning, and Error.
/// </remarks>
public class NLogLogger(Type type) : ILogger
{
    static NLogLogger()
    {
        NLogSetup.Configure();
    }

    private readonly Logger _logger = LogManager.GetLogger(type.FullName ?? "NA");

    public void LogDebug(string message) => _logger.Debug(message);
    public void LogInfo(string message) => _logger.Info(message);
    public void LogWarning(string message) => _logger.Warn(message);
    public void LogError(string message) => _logger.Error(message);
}
