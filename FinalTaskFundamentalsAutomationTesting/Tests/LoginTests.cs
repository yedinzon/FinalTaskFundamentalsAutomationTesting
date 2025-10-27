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
    /// <param name="username">The username to be used in the test.</param>
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
    /// <param name="username">The valid username to be used in the test.</param>
    /// <param name="password">The valid password to be used in the test.</param>
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

//TODO: Diferentes SO
