using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace FinalTaskFundamentalsAutomationTesting.Core.BrowserFactory;

public class EdgeFactory : IBrowserFactory
{
    /// <summary>
    /// Creates a new instance of Edge WebDriver with specified options.
    /// </summary>
    /// <returns>An instance of IWebDriver for Edge browser.</returns>
    public IWebDriver CreateWebDriver()
    {
        var options = new EdgeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-notifications");
        return new EdgeDriver(options);
    }
}
