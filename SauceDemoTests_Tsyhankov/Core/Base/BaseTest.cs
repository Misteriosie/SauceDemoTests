using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SauceDemoTests_Tsyhankov.Core.Config;
using SauceDemoTests_Tsyhankov.Core.Driver;
using SauceDemoTests_Tsyhankov.Core.Logging;

namespace SauceDemoTests_Tsyhankov.Core.Base;

public abstract class BaseTest
{
    private IWebDriver? driver;

    protected IWebDriver Driver =>
        this.driver ?? throw new InvalidOperationException("WebDriver is not initialized.");

    protected TestSettings Settings { get; private set; } = null!;

    [SetUp]
    public void SetUp()
    {
        this.Settings = TestSettings.Load();

        BrowserType browserType = ResolveBrowserType();

        TestLogger.StartTest(TestContext.CurrentContext.Test.Name);
        TestLogger.Info($"Browser: {browserType}");

        this.driver = DriverFactory.CreateDriver(browserType, this.Settings.Headless);
        DriverManager.SetDriver(this.driver);
    }

    [TearDown]
    public void TearDown()
    {
        TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

        if (status == TestStatus.Failed)
        {
            TestLogger.Error($"Test failed: {TestContext.CurrentContext.Result.Message}");
        }

        try
        {
            this.driver?.Quit();
            this.driver?.Dispose();
        }
        finally
        {
            this.driver = null;
            DriverManager.ClearDriver();
            TestLogger.EndTest(TestContext.CurrentContext.Test.Name);
        }
    }

    private static BrowserType ResolveBrowserType()
    {
        object?[] arguments = TestContext.CurrentContext.Test.Arguments;

        if (arguments.Length > 0 && arguments[0] is BrowserType browserType)
        {
            return browserType;
        }

        return BrowserType.Edge;
    }
}