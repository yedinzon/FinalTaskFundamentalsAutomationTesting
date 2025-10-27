using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Core.BrowserFactory;

public interface IBrowserFactory
{
    /// <summary>
    /// Creates a new instance of a WebDriver.
    /// </summary>
    /// <returns>An instance of IWebDriver.</returns>
    IWebDriver CreateWebDriver();
}
