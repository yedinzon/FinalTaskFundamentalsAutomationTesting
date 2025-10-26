using FinalTaskFundamentalsAutomationTesting.Core;
using FinalTaskFundamentalsAutomationTesting.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Tests;

[TestClass]
public abstract class TestBase
{
    protected IWebDriver _webDriver = null!;
    protected static ILogger _logger = null!;

    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static void Initialize(TestContext context)
    {
        NLogSetup.Configure();
        _logger = new NLogLogger(typeof(LoginTests));
        _logger.LogInfo("Test initialization started.");
    }

    protected void SetupWebDriver(BrowserType browserType)
    {
        _webDriver ??= WebDriverFactory.Create(browserType);
        _logger.LogInfo($"WebDriver initialized for {browserType}.");
    }

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
