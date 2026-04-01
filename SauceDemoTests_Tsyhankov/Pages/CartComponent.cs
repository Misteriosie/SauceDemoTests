using OpenQA.Selenium;
using SauceDemoTests_Tsyhankov.Core.Base;
using SauceDemoTests_Tsyhankov.Core.Logging;

namespace SauceDemoTests_Tsyhankov.Pages;

public sealed class CartComponent : BasePage
{
    private readonly By cartBadge = By.CssSelector("span.shopping_cart_badge");

    public CartComponent(IWebDriver driver, int timeoutSeconds)
        : base(driver, timeoutSeconds)
    {
    }

    public int GetItemsCount()
    {
        TestLogger.Info("Reading shopping cart badge count.");

        if (!this.IsVisible(this.cartBadge))
        {
            return 0;
        }

        string badgeText = this.GetText(this.cartBadge);
        return int.Parse(badgeText);
    }
}