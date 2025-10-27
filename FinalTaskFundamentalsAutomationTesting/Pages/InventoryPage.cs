using FinalTaskFundamentalsAutomationTesting.Core.Logging;
using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Pages;

public class InventoryPage(IWebDriver webDriver, ILogger logger) : BasePage(webDriver, logger)
{
    private static By DashboardTitle => By.ClassName("app_logo");
    public string GetDashboardTitle() => GetTextLocator(DashboardTitle);
}
