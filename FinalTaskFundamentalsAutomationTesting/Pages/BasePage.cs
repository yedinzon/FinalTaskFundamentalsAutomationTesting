using FinalTaskFundamentalsAutomationTesting.Core.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FinalTaskFundamentalsAutomationTesting.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver _webDriver;
    protected readonly ILogger _logger;

    protected BasePage(IWebDriver webDriver, ILogger logger)
    {
        _webDriver = webDriver;
        _logger = logger;
    }

    protected string GetTextLocator(By locator)
    {
        try
        {
            var text = _webDriver.FindElement(locator).Text;
            _logger.LogDebug($"Retrieved {locator}: {text}");
            return text;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving {locator}: {ex.Message}");
            throw;
        }
    }

    protected void TypeText(By locator, string text)
    {
        try
        {
            var element = _webDriver.FindElement(locator);
            element.SendKeys(text);
            _logger.LogDebug($"Typed text '{text}' into element {locator}.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error typing text '{text}' into element {locator}: {ex.Message}");
            throw;
        }
    }

    protected void ClearInput(By locator)
    {
        try
        {
            var input = _webDriver.FindElement(locator);
            var actions = new Actions(_webDriver);

            actions
                .Click(input)
                .KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .SendKeys(Keys.Delete)
                .Perform();

            new WebDriverWait(_webDriver, TimeSpan.FromSeconds(2))
                .Until(driver => input.GetAttribute("value") == string.Empty);

            _logger.LogDebug($"Cleared input field {locator}.");
        }
        catch (Exception)
        {
            _logger.LogError($"Error clearing input field {locator}.");
            throw;
        }
    }
}
