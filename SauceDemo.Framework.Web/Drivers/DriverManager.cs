using System.Threading;
using OpenQA.Selenium;

namespace SauceDemo.Framework.Web.Drivers;

public static class DriverManager
{
    private static readonly AsyncLocal<IWebDriver?> CurrentDriver = new();

    public static IWebDriver Driver =>
        CurrentDriver.Value ?? throw new InvalidOperationException("WebDriver was not initialized for the current test.");

    public static void SetDriver(IWebDriver driver)
    {
        CurrentDriver.Value = driver;
    }

    public static void ClearDriver()
    {
        CurrentDriver.Value = null;
    }
}