using OpenQA.Selenium;
using SauceDemo.Framework.Pages.Base;
using SauceDemo.Framework.Web.Utilities;
using SauceDemo.Framework.Web.Waits;
using SauceDemo.Framework.Web.Logging;

namespace SauceDemo.Framework.Pages.Components;

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