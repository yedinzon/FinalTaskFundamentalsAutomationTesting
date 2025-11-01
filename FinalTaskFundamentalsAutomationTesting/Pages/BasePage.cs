using FinalTaskFundamentalsAutomationTesting.Helpers.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;

namespace FinalTaskFundamentalsAutomationTesting.Pages;

public abstract class BasePage
{
    /// <summary>
    /// Instance of IWebDriver to interact with the web browser.
    /// </summary>
    protected readonly IWebDriver _webDriver;

    /// <summary>
    /// Instance of ILogger for logging purposes.
    /// </summary>
    protected readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the BasePage class with the specified WebDriver and Logger.
    /// </summary>
    /// <param name="webDriver">The WebDriver instance to use for browser interactions.</param>
    /// <param name="logger">The Logger instance to use for logging.</param>
    protected BasePage(IWebDriver webDriver, ILogger logger)
    {
        _webDriver = webDriver;
        _logger = logger;
    }

    /// <summary>
    /// Gets the text of a web element identified by the specified locator.
    /// </summary>
    /// <param name="locator">The locator of the web element.</param>
    /// <returns>The text of the web element.</returns>    
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

    /// <summary>
    /// Types the specified text into a web element identified by the given locator.
    /// </summary>
    /// <param name="locator">The locator of the web element.</param>
    /// <param name="text">The text to type into the web element.</param>
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

    /// <summary>
    /// Clears the input field identified by the specified locator.
    /// </summary>
    /// <param name="locator">The locator of the input field to clear.</param>
    protected void ClearInput(By locator)
    {
        try
        {
            var input = _webDriver.FindElement(locator);
            var selectAllKey = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? Keys.Meta : Keys.Control;

            var actions = new Actions(_webDriver);
            actions
                .Click(input)
                .KeyDown(selectAllKey)
                .SendKeys("a")
                .KeyUp(selectAllKey)
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
