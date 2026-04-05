using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SauceDemo.Framework.Web.Waits;

namespace SauceDemo.Framework.Web.Utilities;

public sealed class ElementActions
{
    private readonly IWebDriver driver;
    private readonly WaitHelper waitHelper;

    public ElementActions(IWebDriver driver, WaitHelper waitHelper)
    {
        this.driver = driver;
        this.waitHelper = waitHelper;
    }

    public void Click(By locator)
    {
        IWebElement element = this.waitHelper.UntilClickable(locator);
        element.Click();
    }

    public void TypeText(By locator, string text)
    {
        IWebElement element = this.waitHelper.UntilVisible(locator);
        element.Clear();
        element.SendKeys(text);
    }

    public void Clear(By locator)
    {
        IWebElement element = this.waitHelper.UntilVisible(locator);

        element.Click();
        element.SendKeys(Keys.Control + "a");
        element.SendKeys(Keys.Delete);

        if (!string.IsNullOrEmpty(element.GetAttribute("value")))
        {
            element.Clear();
        }

        if (!string.IsNullOrEmpty(element.GetAttribute("value")))
        {
            ((IJavaScriptExecutor)this.driver).ExecuteScript("arguments[0].value = '';", element);
        }
    }

    public string GetText(By locator)
    {
        IWebElement element = this.waitHelper.UntilVisible(locator);
        return element.Text.Trim();
    }

    public string GetValue(By locator)
    {
        IWebElement element = this.waitHelper.UntilVisible(locator);
        return element.GetAttribute("value") ?? string.Empty;
    }

    public bool IsVisible(By locator)
    {
        try
        {
            return this.waitHelper.UntilVisible(locator).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public int GetElementsCount(By locator)
    {
        return this.driver.FindElements(locator).Count;
    }
}