using FinalTaskFundamentalsAutomationTesting.Core;

namespace FinalTaskFundamentalsAutomationTesting.Tests.TestData;

public static class LoginTestData
{
    public static IEnumerable<object[]> EmptyCredentialsTestData()
    {
        yield return new object[] { BrowserType.Chrome };
        yield return new object[] { BrowserType.Edge };
    }

    public static IEnumerable<object[]> CredentialsUsernameOnlyTestData()
    {
        yield return new object[] { BrowserType.Chrome, "user-test" };
        yield return new object[] { BrowserType.Edge, "user-test" };
    }

    public static IEnumerable<object[]> ValidCredentialsTestData()
    {
        yield return new object[] { BrowserType.Chrome, "standard_user", "secret_sauce" };
        yield return new object[] { BrowserType.Edge, "standard_user", "secret_sauce" };
    }
}
