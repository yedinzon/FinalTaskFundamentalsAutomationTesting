using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace FinalTaskFundamentalsAutomationTesting.Core.BrowserFactory;

public class EdgeFactory : IBrowserFactory
{
    public IWebDriver CreateWebDriver()
    {
        var options = new EdgeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-notifications");
        return new EdgeDriver(options);
    }
}
