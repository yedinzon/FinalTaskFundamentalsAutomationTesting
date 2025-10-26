using FinalTaskFundamentalsAutomationTesting.Core;
using FinalTaskFundamentalsAutomationTesting.Pages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinalTaskFundamentalsAutomationTesting.Tests;

[TestClass]
public class LoginTests : TestBase
{
    /// <summary>
    /// Verifies that the login form displays an error message 
    /// when attempting to log in with empty credentials.
    /// </summary>
    /// <param name="browserType">The browser in which the test will run (Chrome, Edge, etc.).</param>
    /*
    Feature: Login Validation
      As a user of the application
      I want to be informed when required fields are missing
      so that I can provide the correct login information

      Scenario: Login with empty credentials
        Given the user is on the login page
        When he enters credentials and then clears both fields and clicks the Login button
        Then an error message "Username is required" should be displayed
    */
    [TestMethod]
    [DataRow(BrowserType.Chrome)]
    [DataRow(BrowserType.Edge)]
    public void LoginWithEmptyCredentials_ShouldShow_UsernameError(BrowserType browserType)
    {
        // Given
        var driver = GetDriver(browserType);
        var loginPage = new LoginPage(driver);
        loginPage.Open();

        // When
        loginPage.EnterCredentialsAndThenClear("user-test", "password-test");
        loginPage.ClickLoginButton();

        // Then
        var errorMessage = loginPage.GetErrorMessage();
        errorMessage.Should().Contain("Username is required");
    }
}

//TODO: Complete readme
//TODO: Complete doc
//TODO: Complete tests
//TODO: LoginPage, validate try-catch in methods
