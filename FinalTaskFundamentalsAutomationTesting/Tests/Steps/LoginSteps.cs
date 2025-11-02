using FinalTaskFundamentalsAutomationTesting.Core;
using FinalTaskFundamentalsAutomationTesting.Core.BrowserFactory;
using FinalTaskFundamentalsAutomationTesting.Helpers;
using FinalTaskFundamentalsAutomationTesting.Helpers.Logging;
using FinalTaskFundamentalsAutomationTesting.Models;
using FinalTaskFundamentalsAutomationTesting.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using Reqnroll;

namespace FinalTaskFundamentalsAutomationTesting.Tests.Steps;

[Binding]
public class LoginSteps(ScenarioContext scenarioContext)
{
    private IWebDriver _webDriver = null!;
    private LoginPage _loginPage = null!;
    private InventoryPage _inventoryPage = null!;
    private readonly NLogLogger _logger = new(typeof(LoginSteps));
    private readonly ScenarioContext _scenarioContext = scenarioContext;

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        UserDataProvider.LoadUserData();
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _logger.LogInfo($"Starting scenario: {_scenarioContext.ScenarioInfo.Title}");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _logger.LogInfo($"Completed scenario: {_scenarioContext.ScenarioInfo.Title}");

        try
        {
            _webDriver?.Quit();
            _logger.LogInfo("AfterScenario: WebDriver quit successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"AfterScenario error: {ex.Message}");
        }
    }

    [Given("I am on the login page in \"(.*)\" browser")]
    public void GivenIAmOnTheLoginPageInBrowser(string browserName)
    {
        SetWebDriver(browserName);

        _loginPage = new LoginPage(_webDriver, _logger);
        _loginPage.Open();
        _logger.LogInfo($"Opened login page in {browserName} browser.");
    }

    [When("I attempt to login with empty credentials")]
    public void WhenIAttemptToLoginWithEmptyCredentials()
    {
        _loginPage.EnterCredentialsAndThenClear("user-test", "password-test");
        _loginPage.ClickLoginButton();
        _logger.LogInfo("Clicked Login button after clearing credentials.");
    }

    [When("I attempt to login with username and empty password from user \"(.*)\"")]
    public void WhenIAttemptToLoginWithUsernameAndEmptyPassword(string userKey)
    {
        UserData user = UserDataProvider.GetUserData(userKey);

        _loginPage.EnterCredentialsAndThenClear(user.Username, "password-test", clearPasswordOnly: true);
        _loginPage.ClickLoginButton();
        _logger.LogInfo($"Clicked Login button after clearing the password field for username: {user.Username}");
    }

    [When("I login with username and password from user \"(.*)\"")]
    public void WhenILoginWithUsernameAndPassword(string userKey)
    {
        UserData user = UserDataProvider.GetUserData(userKey);

        _loginPage.EnterCredentials(user.Username, user.Password);
        _loginPage.ClickLoginButton();
        _logger.LogInfo("Clicked Login button with valid credentials.");
    }

    [Then("I should see an error message containing \"(.*)\"")]
    public void ThenIShouldSeeAnErrorMessageContaining(string expectedErrorMessage)
    {
        string errorMessage = _loginPage.GetErrorMessage();
        _logger.LogInfo($"Error message displayed: {errorMessage}");

        _loginPage.IsErrorMessageDisplayed().Should().BeTrue("Error message should be displayed");
        errorMessage.Should().Contain(expectedErrorMessage);
        _logger.LogInfo($"Successfully verified error message contains: {expectedErrorMessage}");
    }

    [Then("I should be redirected to the dashboard with title \"(.*)\"")]
    public void ThenIShouldBeRedirectedToTheDashboardWithTitle(string expectedTitle)
    {
        _inventoryPage = new InventoryPage(_webDriver, _logger);
        string dashboardTitle = _inventoryPage.GetDashboardTitle();
        _logger.LogInfo($"Dashboard title displayed: {dashboardTitle}");

        dashboardTitle.Should().Be(expectedTitle);
        _logger.LogInfo($"Successfully verified dashboard title: {expectedTitle}");
    }

    /// <summary>
    /// Sets up the WebDriver based on the specified browser name.
    /// </summary>
    /// <param name="browserName"></param>
    private void SetWebDriver(string browserName)
    {
        if (!Enum.TryParse(browserName, out BrowserType parsedBrowser))
        {
            _logger.LogError($"Unsupported browser type: {browserName}");
            throw new ArgumentException($"Unsupported type browser: {browserName}");
        }

        _webDriver = WebDriverFactory.Create(parsedBrowser);
        _logger.LogInfo($"WebDriver initialized for {browserName}.");
    }
}
