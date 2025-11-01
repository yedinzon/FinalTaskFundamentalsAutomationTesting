using FinalTaskFundamentalsAutomationTesting.Helpers.Logging;
using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Pages;

public class LoginPage(IWebDriver webDriver, ILogger logger) : BasePage(webDriver, logger)
{
    /// <summary>
    /// URL of the login page.
    /// </summary>
    private readonly string _url = "https://www.saucedemo.com/";

    /// <summary>
    /// By locators for the login page elements.
    /// </summary>
    private static By UsernameInput => By.Id("user-name");

    /// <summary>
    /// By locator for the password input field.
    /// </summary>
    private static By PasswordInput => By.Id("password");

    /// <summary>
    /// By locator for the login button.
    /// </summary>
    private static By LoginButton => By.Id("login-button");

    /// <summary>
    /// By locator for the error message element.
    /// </summary>
    private static By ErrorMessage => By.CssSelector("h3[data-test='error']");

    /// <summary>
    /// Enters the specified username and password, then clears the inputs.
    /// </summary>
    /// <param name="username">The username to enter</param>
    /// <param name="password">The password to enter</param>
    /// <param name="clearPasswordOnly">If true, only the password field will be cleared; 
    /// otherwise, both fields will be cleared</param>
    public void EnterCredentialsAndThenClear(string username, string password, bool clearPasswordOnly = false)
    {
        EnterCredentials(username, password);
        ClearCredentials(clearPasswordOnly);
    }

    /// <summary>
    /// Enters the specified username and password into their respective input fields.
    /// </summary>
    /// <param name="username">The username to enter</param>
    /// <param name="password">The password to enter</param>
    public void EnterCredentials(string username, string password)
    {
        TypeUsername(username);
        TypePassword(password);
    }

    /// <summary>
    /// Clears the username and password input fields.
    /// </summary>
    /// <param name="clearPasswordOnly">If true, only the password field will be cleared; 
    /// otherwise, both fields will be cleared</param>
    public void ClearCredentials(bool clearPasswordOnly = false)
    {
        if (!clearPasswordOnly)
        {
            ClearUsername();
        }

        ClearPassword();
    }

    /// <summary>
    /// Types the specified username into the username input field.
    /// </summary>
    /// <param name="username">The username to type</param>
    public void TypeUsername(string username) => TypeText(UsernameInput, username);

    /// <summary>
    /// Types the specified password into the password input field.
    /// </summary>
    /// <param name="password">The password to type</param>
    public void TypePassword(string password) => TypeText(PasswordInput, password);

    /// <summary>
    /// Clears the username input field.
    /// </summary>
    public void ClearUsername() => ClearInput(UsernameInput);

    /// <summary>
    /// Clears the password input field.
    /// </summary>
    public void ClearPassword() => ClearInput(PasswordInput);

    /// <summary>
    /// Gets the error message text displayed on the login page.
    /// </summary>
    /// <returns></returns>
    public string GetErrorMessage() => GetTextLocator(ErrorMessage);

    /// <summary>
    /// Opens the login page URL in the web driver.
    /// </summary>
    public void Open()
    {
        try
        {
            _webDriver.Navigate().GoToUrl(_url);
            _logger.LogDebug($"Opened login page {_url}.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error opening login page: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Clicks the login button on the login page.
    /// </summary>
    public void ClickLoginButton()
    {
        try
        {
            _webDriver.FindElement(LoginButton).Click();
            _logger.LogDebug("Clicked Login button.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error clicking: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Checks if the error message is displayed on the login page.
    /// </summary>
    /// <returns>True if the error message is displayed; otherwise, false.</returns>
    public bool IsErrorMessageDisplayed()
    {
        try
        {
            var isDisplayed = _webDriver.FindElement(ErrorMessage).Displayed;
            _logger.LogDebug($"Error message displayed: {isDisplayed}");
            return isDisplayed;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error checking error message display: {ex.Message}");
            throw;
        }
    }
}
