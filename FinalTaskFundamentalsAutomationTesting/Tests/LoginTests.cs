using FinalTaskFundamentalsAutomationTesting.Core;
using FinalTaskFundamentalsAutomationTesting.Pages;
using FinalTaskFundamentalsAutomationTesting.Tests.TestData;
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
    Feature UC1: Login Validation
      As a user of the application
      I want to be informed when required fields are missing
      so that I can provide the correct login information

      Scenario: Login with empty credentials
        Given the user is on the login page
        When he enters credentials and then clears both fields and clicks the Login button
        Then an error message "Username is required" should be displayed
    */
    [DataTestMethod]
    [DynamicData(nameof(LoginTestData.EmptyCredentialsTestData), typeof(LoginTestData), DynamicDataSourceType.Method)]
    public void UC1_LoginWithEmptyCredentials_ShouldShow_UsernameError(BrowserType browserType)
    {
        // Given
        _logger.LogInfo($"Starting UC-1 test on {browserType}: UC1_LoginWithEmptyCredentials_ShouldShow_UsernameError");
        SetupWebDriver(browserType);
        var loginPage = new LoginPage(_webDriver, _logger);
        loginPage.Open();
        _logger.LogInfo("Opened login page.");

        // When
        loginPage.EnterCredentialsAndThenClear("user-test", "password-test");
        loginPage.ClickLoginButton();
        _logger.LogInfo("Clicked Login button after clearing credentials.");

        // Then
        string errorMessage = loginPage.GetErrorMessage();
        _logger.LogInfo($"Error message displayed: {errorMessage}");

        errorMessage.Should().Contain("Username is required");
        _logger.LogInfo("UC-1 test completed successfully.");
    }

    /// <summary>
    /// Verifies that the login form displays an error message 
    /// when attempting to log in with only the username and empty password.
    /// </summary>
    /// <param name="browserType">The browser in which the test will run (Chrome, Edge, etc.).</param>
    /*
     Feature UC2: Login Validation
       As a user of the application
       I want to be informed when required fields are missing
       so that I can provide the correct login information

       Scenario: Login with credentials by passing Username
         Given the user is on the login page
         When he enters a username, enters a password, then clears the password and clicks the Login button
         Then an error message "Password is required" should be displayed
     */
    [DataTestMethod]
    [DynamicData(nameof(LoginTestData.CredentialsUsernameOnlyTestData), typeof(LoginTestData), DynamicDataSourceType.Method)]
    public void UC2_LoginWithUsernameOnly_ShouldShow_PasswordError(BrowserType browserType, string username)
    {
        // Given
        _logger.LogInfo($"Starting UC-2 test on {browserType}: UC2_LoginWithUsernameOnly_ShouldShow_PasswordError");
        SetupWebDriver(browserType);
        var loginPage = new LoginPage(_webDriver, _logger);
        loginPage.Open();
        _logger.LogInfo("Opened login page.");

        // When
        loginPage.EnterCredentialsAndThenClear(username, "password-test", clearPasswordOnly: true);
        loginPage.ClickLoginButton();
        _logger.LogInfo("Clicked Login button after clearing the password field.");

        // Then
        string errorMessage = loginPage.GetErrorMessage();
        _logger.LogInfo($"Error message displayed: {errorMessage}");

        errorMessage.Should().Contain("Password is required");
        _logger.LogInfo("UC-2 test completed successfully.");
    }

    /// <summary>
    /// Verifies that the login form allows access when using valid credentials 
    /// and navigates to the dashboard displaying the correct title.
    /// </summary>
    /// <param name="browserType">The browser in which the test will run (Chrome, Edge, etc.).</param>
    /*
     Feature UC3: Login Success
       As a user of the application
       I want to log in with valid credentials
       so that I can access the dashboard and perform actions

       Scenario: Login with accepted credentials
         Given the user is on the login page
         When he enters a valid username and the password "secret_sauce" and clicks the Login button
         Then the dashboard should be displayed with the title "Swag Labs"
     */
    [DataTestMethod]
    [DynamicData(nameof(LoginTestData.ValidCredentialsTestData), typeof(LoginTestData), DynamicDataSourceType.Method)]
    public void UC3_LoginWithValidCredentials_ShouldNavigateToDashboard(BrowserType browserType, string username, string password)
    {
        // Given
        _logger.LogInfo($"Starting UC-3 test on {browserType}: UC3_LoginWithValidCredentials_ShouldNavigateToDashboard");
        SetupWebDriver(browserType);
        var loginPage = new LoginPage(_webDriver, _logger);
        loginPage.Open();
        _logger.LogInfo("Opened login page.");

        // When
        loginPage.EnterCredentials(username, password);
        loginPage.ClickLoginButton();
        _logger.LogInfo("Clicked Login button with valid credentials.");

        // Then    
        var inventoryPage = new InventoryPage(_webDriver, _logger);
        var dashboardTitle = inventoryPage.GetDashboardTitle();
        _logger.LogInfo($"Dashboard title displayed: {dashboardTitle}");

        dashboardTitle.Should().Be("Swag Labs");
        _logger.LogInfo("UC-3 test completed successfully.");
    }
}

//TODO: Complete readme
//TODO: Complete doc
//TODO: Diferentes SO
//TODO: Verify disign patterns
