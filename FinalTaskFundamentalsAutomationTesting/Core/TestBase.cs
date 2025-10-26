using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Core;

public abstract class TestBase
{
    private IWebDriver? _webDriver;

    protected IWebDriver GetDriver(BrowserType browserType)
    {
        _webDriver ??= WebDriverFactory.Create(browserType);

        return _webDriver;
    }

    [TestCleanup]
    public void Cleanup()
    {
        try
        {
            _webDriver?.Quit();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Cleanup warning: {ex.Message}");
        }
    }
}
