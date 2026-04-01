using OpenQA.Selenium;
using SauceDemoTests_Tsyhankov.Core.Base;
using SauceDemoTests_Tsyhankov.Core.Logging;

namespace SauceDemoTests_Tsyhankov.Pages;

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