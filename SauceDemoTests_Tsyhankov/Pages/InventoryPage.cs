using OpenQA.Selenium;
using SauceDemoTests_Tsyhankov.Core.Base;
using SauceDemoTests_Tsyhankov.Core.Logging;

namespace SauceDemoTests_Tsyhankov.Pages;

public sealed class InventoryPage : BasePage
{
    private readonly By burgerMenuButton = By.CssSelector("button#react-burger-menu-btn");
    private readonly By appLogo = By.CssSelector("div.app_logo");
    private readonly By shoppingCartLink = By.CssSelector("a.shopping_cart_link");
    private readonly By sortDropdown = By.CssSelector("select[data-test='product-sort-container']");
    private readonly By inventoryItems = By.CssSelector("div.inventory_item");
    private readonly By inventoryItemNames = By.CssSelector("div.inventory_item_name");

    public InventoryPage(IWebDriver driver, int timeoutSeconds)
        : base(driver, timeoutSeconds)
    {
    }

    public bool IsBurgerMenuDisplayed()
    {
        return this.IsVisible(this.burgerMenuButton);
    }

    public bool IsAppLogoDisplayed()
    {
        return this.IsVisible(this.appLogo);
    }

    public string GetAppLogoText()
    {
        return this.GetText(this.appLogo);
    }

    public bool IsShoppingCartDisplayed()
    {
        return this.IsVisible(this.shoppingCartLink);
    }

    public bool IsSortDropdownDisplayed()
    {
        return this.IsVisible(this.sortDropdown);
    }

    public int GetInventoryItemsCount()
    {
        TestLogger.Info("Reading inventory items count.");
        this.WaitUntilAnyElementsPresent(this.inventoryItems);
        return this.GetElementsCount(this.inventoryItems);
    }

    public ProductDetailsPage OpenFirstProduct()
    {
        TestLogger.Info("Opening first product from inventory list.");
        IReadOnlyCollection<IWebElement> products = this.WaitUntilAnyElementsPresent(this.inventoryItemNames);
        IWebElement firstProduct = products.First();
        firstProduct.Click();

        return new ProductDetailsPage(this.Driver, this.TimeoutSeconds);
    }

    public ProductDetailsPage OpenProductByName(string productName)
    {
        TestLogger.Info($"Opening product by name: {productName}");
        IReadOnlyCollection<IWebElement> products = this.WaitUntilAnyElementsPresent(this.inventoryItemNames);

        IWebElement? targetProduct = products.FirstOrDefault(
            product => string.Equals(product.Text.Trim(), productName, StringComparison.Ordinal));

        if (targetProduct is null)
        {
            throw new InvalidOperationException($"Product '{productName}' was not found.");
        }

        targetProduct.Click();
        return new ProductDetailsPage(this.Driver, this.TimeoutSeconds);
    }

    public CartComponent Cart()
    {
        return new CartComponent(this.Driver, this.TimeoutSeconds);
    }
}