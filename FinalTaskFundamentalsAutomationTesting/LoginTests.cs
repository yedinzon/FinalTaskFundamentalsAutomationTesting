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
    public void Test()
    {
        _webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");

        try
        {
            Assert.AreEqual("Swag Labs", _webDriver.Title);
        }
        finally
        {
            _webDriver.Quit();
        }
    }
}
