using FinalTaskFundamentalsAutomationTesting.Core.Logging;
using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Pages;

public class InventoryPage(IWebDriver webDriver, ILogger logger) : BasePage(webDriver, logger)
{
    /// <summary>
    /// By locator for the dashboard title element.
    /// </summary>
    private static By DashboardTitle => By.ClassName("app_logo");

    /// <summary>
    /// Gets the dashboard title text.
    /// </summary>
    /// <returns>The text of the dashboard title element.</returns>
    public string GetDashboardTitle() => GetTextLocator(DashboardTitle);
}
