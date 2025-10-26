using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FinalTaskFundamentalsAutomationTesting.Pages;

public class LoginPage
{
    private readonly IWebDriver _webDriver;
    private readonly string _url = "https://www.saucedemo.com/";

    public LoginPage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    private By UsernameInput => By.Id("user-name");
    private By PasswordInput => By.Id("password");
    private By LoginButton => By.Id("login-button");
    private By ErrorMessage => By.CssSelector("h3[data-test='error']");

    public IWebDriver Open()
    {
        _webDriver.Navigate().GoToUrl(_url);
        return _webDriver;
    }

    public void TypeUsername(string username)
    {
        var usernameInput = _webDriver.FindElement(UsernameInput);
        usernameInput.SendKeys(username);
    }

    public void TypePassword(string password)
    {
        var passwordInput = _webDriver.FindElement(PasswordInput);
        passwordInput.SendKeys(password);
    }

    public void ClearUsername()
    {
        var usernameInput = _webDriver.FindElement(UsernameInput);
        var cleanInputs = new Actions(_webDriver);

        cleanInputs
            .Click(usernameInput)
            .KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control)
            .SendKeys(Keys.Delete)
            .Perform();

        new WebDriverWait(_webDriver, TimeSpan.FromSeconds(2))
            .Until(driver => usernameInput.GetAttribute("value") == string.Empty);
    }

    public void ClearPassword()
    {
        var passwordInput = _webDriver.FindElement(PasswordInput);
        var cleanInputs = new Actions(_webDriver);

        cleanInputs
            .Click(passwordInput)
            .KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control)
            .SendKeys(Keys.Delete)
            .Perform();

        new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5))
            .Until(driver => passwordInput.GetAttribute("value") == string.Empty);
    }

    public void ClickLoginButton()
    {
        var loginButton = _webDriver.FindElement(LoginButton);
        loginButton.Click();
    }

    public string GetErrorMessage()
    {
        try
        {
            return _webDriver.FindElement(ErrorMessage).Text;
        }
        catch (NoSuchElementException)
        {
            return string.Empty;
        }
    }
}
