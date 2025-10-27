using NLog;

namespace FinalTaskFundamentalsAutomationTesting.Core.Logging;

public class NLogLogger(Type type) : ILogger
{
    /// <summary>
    /// Logger instance from NLog.
    /// </summary>
    private readonly Logger _logger = LogManager.GetLogger(type.FullName ?? "NA");

    /// <summary>
    /// Logs a debug message.
    /// </summary>
    /// <param name="message">The debug message to log.</param>
    public void LogDebug(string message) => _logger.Debug(message);

    /// <summary>
    /// Logs an informational message.
    /// </summary>
    /// <param name="message">The informational message to log.</param>
    public void LogInfo(string message) => _logger.Info(message);

    /// <summary>
    /// Logs a warning message.
    /// </summary>
    /// <param name="message">The warning message to log.</param>
    public void LogWarning(string message) => _logger.Warn(message);

    /// <summary>
    /// Logs an error message.
    /// </summary>
    /// <param name="message">The error message to log.</param>
    public void LogError(string message) => _logger.Error(message);
}
