using OpenQA.Selenium;
using SauceDemo.Framework.Web.Waits;
using SauceDemo.Framework.Web.Utilities;


namespace SauceDemo.Framework.Pages.Base;

public abstract class BasePage
{
    protected BasePage(IWebDriver driver, int timeoutSeconds)
    {
        this.Driver = driver;
        this.TimeoutSeconds = timeoutSeconds;
        this.WaitHelper = new WaitHelper(driver, timeoutSeconds);
        this.Actions = new ElementActions(driver, this.WaitHelper);
    }

    protected IWebDriver Driver { get; }

    protected int TimeoutSeconds { get; }

    protected WaitHelper WaitHelper { get; }

    protected ElementActions Actions { get; }

    protected void NavigateTo(string url)
    {
        this.Driver.Navigate().GoToUrl(url);
    }

    protected void Click(By locator)
    {
        this.Actions.Click(locator);
    }

    protected void TypeText(By locator, string text)
    {
        this.Actions.TypeText(locator, text);
    }

    protected void Clear(By locator)
    {
        this.Actions.Clear(locator);
    }

    protected string GetText(By locator)
    {
        return this.Actions.GetText(locator);
    }

    protected string GetValue(By locator)
    {
        return this.Actions.GetValue(locator);
    }

    protected bool IsVisible(By locator)
    {
        return this.Actions.IsVisible(locator);
    }

    protected int GetElementsCount(By locator)
    {
        return this.Actions.GetElementsCount(locator);
    }

    protected IReadOnlyCollection<IWebElement> WaitUntilAnyElementsPresent(By locator)
    {
        return this.WaitHelper.UntilAnyElementsPresent(locator);
    }
}