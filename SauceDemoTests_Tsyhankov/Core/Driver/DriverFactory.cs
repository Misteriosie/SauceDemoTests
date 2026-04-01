using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SauceDemoTests_Tsyhankov.Core.Driver;

public static class DriverFactory
{
    public static IWebDriver CreateDriver(BrowserType browserType, bool headless)
    {
        IWebDriver driver = browserType switch
        {
            BrowserType.Firefox => CreateFirefoxDriver(headless),
            BrowserType.Edge => CreateEdgeDriver(headless),
            _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType, "Unsupported browser."),
        };

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        driver.Manage().Window.Maximize();

        return driver;
    }

    private static IWebDriver CreateFirefoxDriver(bool headless)
    {
        var options = new FirefoxOptions();

        if (headless)
        {
            options.AddArgument("-headless");
        }

        return new FirefoxDriver(options);
    }

    private static IWebDriver CreateEdgeDriver(bool headless)
    {
        var options = new EdgeOptions();

        if (headless)
        {
            options.AddArgument("headless=new");
        }

        return new EdgeDriver(options);
    }
}