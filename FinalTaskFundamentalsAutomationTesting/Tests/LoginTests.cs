using FinalTaskFundamentalsAutomationTesting.Core;
using FinalTaskFundamentalsAutomationTesting.Pages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinalTaskFundamentalsAutomationTesting.Tests;

[TestClass]
public class LoginTests : TestBase
{
    [TestMethod]
    [DataRow(BrowserType.Chrome)]
    [DataRow(BrowserType.Edge)]
    public void LoginWithEmptyCredentials_ShouldShow_UsernameError(BrowserType browserType)
    {
        var driver = GetDriver(browserType);
        var loginPage = new LoginPage(driver);
        loginPage.Open();
        loginPage.TypeUsername("user-test");
        loginPage.TypePassword("password-test");
        loginPage.ClearUsername();
        loginPage.ClearPassword();
        loginPage.ClickLoginButton();
        var errorMessage = loginPage.GetErrorMessage();
        errorMessage.Should().Contain("Username is required");
    }
}
