using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FinalTaskFundamentalsAutomationTesting;

[TestClass]
public class LoginTests
{
    private readonly IWebDriver _webDriver;
    public LoginTests()
    {
        var options = new ChromeOptions();
        _webDriver = new ChromeDriver(options);
    }

    [TestMethod]
    public void LoginWithEmptyCredentials_ShouldShow_UsernameError()
    {
        _webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");

        var usernameInput = _webDriver.FindElement(By.Id("user-name"));
        var passwordInput = _webDriver.FindElement(By.Id("password"));
        var loginButton = _webDriver.FindElement(By.Id("login-button"));

        usernameInput.SendKeys("user-test1");
        passwordInput.SendKeys("password-test");

        var cleanInputs = new Actions(_webDriver);

        cleanInputs
            .Click(usernameInput)
            .KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control)
            .SendKeys(Keys.Delete)
            .Click(passwordInput)
            .KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control)
            .SendKeys(Keys.Delete)
            .Perform();

        new WebDriverWait(_webDriver, TimeSpan.FromSeconds(2))
            .Until(driver =>
                usernameInput.GetAttribute("value") == "" &&
                passwordInput.GetAttribute("value") == "");

        loginButton.Click();

        var errorMessage = _webDriver.FindElement(By.CssSelector("h3[data-test='error']"));

        try
        {
            Assert.IsTrue(errorMessage.Text.Contains("Username is required"));
        }
        finally
        {
            _webDriver.Quit();
        }
    }
}
