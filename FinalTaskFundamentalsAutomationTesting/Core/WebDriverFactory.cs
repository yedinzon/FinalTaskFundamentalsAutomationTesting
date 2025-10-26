using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace FinalTaskFundamentalsAutomationTesting.Core;

public static class WebDriverFactory
{
    public static IWebDriver Create(BrowserType browserType)
    {
        return browserType switch
        {
            BrowserType.Chrome => new ChromeDriver(),
            BrowserType.Edge => new EdgeDriver(),
            _ => throw new NotSupportedException($"Browser type '{browserType}' is not supported.")
        };
    }
}
