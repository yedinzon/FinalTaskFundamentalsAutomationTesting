using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Core.BrowserFactory;

public static class WebDriverFactory
{
    /// <summary>
    /// Creates a new instance of IWebDriver based on the specified browser type.
    /// </summary>
    /// <param name="browserType">The type of browser for which to create the WebDriver.</param>
    /// <returns>An instance of IWebDriver for the specified browser.</returns>
    /// <exception cref="NotSupportedException">Thrown when the specified browser type is not supported.</exception>
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
