using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Core.BrowserFactory;

public interface IBrowserFactory
{
    IWebDriver CreateWebDriver();
}
