using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalTaskFundamentalsAutomationTesting.Core.BrowserFactory;

public class ChromeFactory : IBrowserFactory
{
    public IWebDriver CreateWebDriver()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-notifications");
        return new ChromeDriver(options);
    }
}
