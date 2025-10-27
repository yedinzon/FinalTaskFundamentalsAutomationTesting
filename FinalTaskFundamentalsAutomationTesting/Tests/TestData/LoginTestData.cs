using FinalTaskFundamentalsAutomationTesting.Core;

namespace FinalTaskFundamentalsAutomationTesting.Tests.TestData;

public static class LoginTestData
{
    /// <summary>
    /// Test data for empty credentials scenario.
    /// </summary>
    /// <returns>An enumerable of object arrays containing browser types.</returns>
    public static IEnumerable<object[]> EmptyCredentialsTestData()
    {
        yield return new object[] { BrowserType.Chrome };
        yield return new object[] { BrowserType.Edge };
    }

    /// <summary>
    /// Test data for credentials with only username provided.
    /// </summary>
    /// <returns>An enumerable of object arrays containing browser types and usernames.</returns>
    public static IEnumerable<object[]> CredentialsUsernameOnlyTestData()
    {
        yield return new object[] { BrowserType.Chrome, "user-test" };
        yield return new object[] { BrowserType.Edge, "user-test" };
    }

    /// <summary>
    /// Test data for credentials with valid username and password.
    /// </summary>
    /// <returns>An enumerable of object arrays containing browser types, usernames, and passwords.</returns>
    public static IEnumerable<object[]> ValidCredentialsTestData()
    {
        yield return new object[] { BrowserType.Chrome, "standard_user", "secret_sauce" };
        yield return new object[] { BrowserType.Edge, "standard_user", "secret_sauce" };
    }
}
