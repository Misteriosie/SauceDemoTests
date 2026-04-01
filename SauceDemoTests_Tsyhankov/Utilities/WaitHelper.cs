using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests_Tsyhankov.Utilities;

public sealed class WaitHelper
{
    private readonly WebDriverWait wait;

    public WaitHelper(IWebDriver driver, int timeoutSeconds)
    {
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        this.wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
    }

    public IWebElement UntilVisible(By locator)
    {
        return this.wait.Until(driver =>
        {
            IWebElement element = driver.FindElement(locator);
            return element.Displayed ? element : null!;
        });
    }

    public IWebElement UntilClickable(By locator)
    {
        return this.wait.Until(driver =>
        {
            IWebElement element = driver.FindElement(locator);
            return element.Displayed && element.Enabled ? element : null!;
        });
    }

    public IReadOnlyCollection<IWebElement> UntilAnyElementsPresent(By locator)
    {
        return this.wait.Until(driver =>
        {
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);
            return elements.Count > 0 ? elements : null!;
        });
    }

    public bool UntilTextPresent(By locator, string expectedText)
    {
        return this.wait.Until(driver =>
        {
            IWebElement element = driver.FindElement(locator);
            return element.Text.Contains(expectedText, StringComparison.Ordinal);
        });
    }
}