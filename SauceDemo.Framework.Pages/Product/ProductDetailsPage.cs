using OpenQA.Selenium;
using SauceDemo.Framework.Pages.Base;
using SauceDemo.Framework.Web.Logging;
using SauceDemo.Framework.Pages.Components;

namespace SauceDemo.Framework.Pages.Product;

public sealed class ProductDetailsPage : BasePage
{
    private readonly By addToCartButton = By.CssSelector("button[data-test^='add-to-cart']");
    private readonly By productName = By.CssSelector("div.inventory_details_name");

    public ProductDetailsPage(IWebDriver driver, int timeoutSeconds)
        : base(driver, timeoutSeconds)
    {
    }

    public string GetProductName()
    {
        return this.GetText(this.productName);
    }

    public void AddToCart()
    {
        TestLogger.Info("Adding product to cart.");
        this.Click(this.addToCartButton);
    }

    public CartComponent Cart()
    {
        return new CartComponent(this.Driver, this.TimeoutSeconds);
    }
}