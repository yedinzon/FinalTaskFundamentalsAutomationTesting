using FinalTaskFundamentalsAutomationTesting.Core;
using FinalTaskFundamentalsAutomationTesting.Core.BrowserFactory;
using FinalTaskFundamentalsAutomationTesting.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Tests;

[TestClass]
public abstract class TestBase
{
    /// <summary>
    /// WebDriver instance for browser automation.
    /// </summary>
    protected IWebDriver _webDriver = null!;

    /// <summary>
    /// Logger instance for logging test activities.
    /// </summary>
    protected static ILogger _logger = null!;

    /// <summary>
    /// Initializes the test class by configuring logging and setting up the logger.
    /// </summary>
    /// <param name="context">Test context provided by MSTest framework.</param>
    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static void Initialize(TestContext context)
    {
        NLogSetup.Configure();
        _logger = new NLogLogger(typeof(LoginTests));
        _logger.LogInfo("Test initialization started.");
    }

    /// <summary>
    /// Sets up the WebDriver for the specified browser type.
    /// </summary>
    /// <param name="browserType"></param>
    protected void SetupWebDriver(BrowserType browserType)
    {
        _webDriver ??= WebDriverFactory.Create(browserType);
        _logger.LogInfo($"WebDriver initialized for {browserType}.");
    }

    /// <summary>
    /// Cleans up the WebDriver instance after each test.
    /// </summary>
    [TestCleanup]
    public void Cleanup()
    {
        try
        {
            _webDriver?.Quit();
            _logger.LogInfo("Cleanup: WebDriver quit successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Cleanup error: {ex.Message}");
        }
    }
}
