using FinalTaskFundamentalsAutomationTesting.Core.Logging;
using OpenQA.Selenium;

namespace FinalTaskFundamentalsAutomationTesting.Pages;

public class LoginPage(IWebDriver webDriver, ILogger logger) : BasePage(webDriver, logger)
{
    private readonly string _url = "https://www.saucedemo.com/";

    private static By UsernameInput => By.Id("user-name");
    private static By PasswordInput => By.Id("password");
    private static By LoginButton => By.Id("login-button");
    private static By ErrorMessage => By.CssSelector("h3[data-test='error']");

    public void EnterCredentialsAndThenClear(string username, string password, bool clearPasswordOnly = false)
    {
        TypeUsername(username);
        TypePassword(password);

        if (!clearPasswordOnly)
        {
            ClearUsername();
        }

        ClearPassword();
    }

    public void EnterCredentials(string username, string password)
    {
        TypeUsername(username);
        TypePassword(password);
    }

    public void TypeUsername(string username) => TypeText(UsernameInput, username);

    public void TypePassword(string password) => TypeText(PasswordInput, password);

    public void ClearUsername() => ClearInput(UsernameInput);

    public void ClearPassword() => ClearInput(PasswordInput);

    public string GetErrorMessage() => GetTextLocator(ErrorMessage);

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
}
