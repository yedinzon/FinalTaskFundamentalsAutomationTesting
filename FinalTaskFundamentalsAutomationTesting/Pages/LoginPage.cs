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

    public void TypeUsername(string username) => TypeText(UsernameInput, username);

    public void TypePassword(string password) => TypeText(PasswordInput, password);

    public void ClearUsername() => ClearInput(UsernameInput);

    public void ClearPassword() => ClearInput(PasswordInput);

    public void ClickLoginButton() => _webDriver.FindElement(LoginButton).Click();

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

    private void TypeText(By locator, string text)
    {
        var element = _webDriver.FindElement(locator);
        element.SendKeys(text);
    }

    private void ClearInput(By locator)
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
    }
}
