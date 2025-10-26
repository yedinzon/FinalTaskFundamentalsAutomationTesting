using FinalTaskFundamentalsAutomationTesting.Core.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FinalTaskFundamentalsAutomationTesting.Pages;

public class LoginPage
{
    private readonly IWebDriver _webDriver;
    private readonly ILogger _logger;
    private readonly string _url = "https://www.saucedemo.com/";

    public LoginPage(IWebDriver webDriver, ILogger logger)
    {
        _webDriver = webDriver;
        _logger = logger;
    }

    private By UsernameInput => By.Id("user-name");
    private By PasswordInput => By.Id("password");
    private By LoginButton => By.Id("login-button");
    private By ErrorMessage => By.CssSelector("h3[data-test='error']");

    public void EnterCredentialsAndThenClear(string username, string password)
    {
        TypeUsername(username);
        TypePassword(password);
        ClearUsername();
        ClearPassword();
    }

    public void TypeUsername(string username) => TypeText(UsernameInput, username);

    public void TypePassword(string password) => TypeText(PasswordInput, password);

    public void ClearUsername() => ClearInput(UsernameInput);

    public void ClearPassword() => ClearInput(PasswordInput);

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

    public string GetErrorMessage()
    {
        try
        {
            var errorMessage = _webDriver.FindElement(ErrorMessage).Text;
            _logger.LogDebug($"Retrieved error message: {errorMessage}");
            return errorMessage;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving error message: {ex.Message}");
            throw;
        }
    }

    private void TypeText(By locator, string text)
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

    private void ClearInput(By locator)
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
