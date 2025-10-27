using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Core.BrowserFactory;

public static class WebDriverFactory
{
    public static IWebDriver Create(BrowserType browserType)
    {
        IBrowserFactory factory = browserType switch
        {
            BrowserType.Chrome => new ChromeFactory(),
            BrowserType.Edge => new EdgeFactory(),
            _ => throw new NotSupportedException($"Browser type '{browserType}' is not supported.")
        };

        return factory.CreateWebDriver();
    }
}
