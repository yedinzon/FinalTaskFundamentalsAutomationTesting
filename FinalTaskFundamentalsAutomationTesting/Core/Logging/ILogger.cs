namespace FinalTaskFundamentalsAutomationTesting.Core.Logging;

public interface ILogger
{
    /// <summary>
    /// Logs a debug message.
    /// </summary>
    /// <param name="message">The debug message to log.</param>
    void LogDebug(string message);

    /// <summary>
    /// Logs an informational message.
    /// </summary>
    /// <param name="message">The informational message to log.</param>
    void LogInfo(string message);

    /// <summary>
    /// Logs a warning message.
    /// </summary>
    /// <param name="message">The warning message to log.</param>
    void LogWarning(string message);

    /// <summary>
    /// Logs an error message.
    /// </summary>
    /// <param name="message">The error message to log.</param>
    void LogError(string message);
}
