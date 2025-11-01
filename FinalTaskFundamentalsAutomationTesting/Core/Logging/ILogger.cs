namespace FinalTaskFundamentalsAutomationTesting.Core.Logging;

/// <summary>
/// Defines methods for logging messages at various severity levels.
/// </summary>
public interface ILogger
{
    void LogDebug(string message);
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message);
}
