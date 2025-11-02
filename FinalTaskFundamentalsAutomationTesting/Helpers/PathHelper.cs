namespace FinalTaskFundamentalsAutomationTesting.Helpers;

/// <summary>
/// Provides utility methods to resolve absolute paths used across the project.
/// </summary>
public static class PathHelper
{
    /// <summary>
    /// Gets the absolute path of the project root directory.
    /// </summary>
    private static string ProjectRoot =>
        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

    /// <summary>
    /// Returns the absolute path of a file located in the TestData folder.
    /// </summary>
    /// <param name="fileName">The name of the test data file.</param>
    /// <returns>The absolute path to the specified test data file.</returns>
    public static string GetTestDataPath(string fileName) =>
        Path.Combine(ProjectRoot, "Tests", "TestData", fileName);

    /// <summary>
    /// Returns the absolute path of the Logs directory.
    /// </summary>
    /// <returns>The absolute path to the logs directory.</returns>
    public static string GetLogsPath() =>
        Path.Combine(ProjectRoot, "Logs");
}
