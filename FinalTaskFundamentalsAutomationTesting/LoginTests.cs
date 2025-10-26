using FinalTaskFundamentalsAutomationTesting.Pages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        var loginPage = new LoginPage(_webDriver);

        try
        {
            loginPage.Open();
            loginPage.TypeUsername("user-test");
            loginPage.TypePassword("password-test");
            loginPage.ClearUsername();
            loginPage.ClearPassword();
            loginPage.ClickLoginButton();
            var errorMessage = loginPage.GetErrorMessage();
            errorMessage.Should().Contain("Username is required");
        }
        finally
        {
            _webDriver.Quit();
        }
    }
}
