using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalTaskFundamentalsAutomationTesting.Core.BrowserFactory;

public class ChromeFactory : IBrowserFactory
{
    /// <summary>
    /// Creates a new instance of Chrome WebDriver with specified options.
    /// </summary>
    /// <returns>An instance of IWebDriver for Chrome browser.</returns>
    public IWebDriver CreateWebDriver()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-notifications");
        return new ChromeDriver(options);
    }
}
