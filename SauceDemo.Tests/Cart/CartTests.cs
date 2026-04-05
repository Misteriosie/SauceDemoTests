using FluentAssertions;
using SauceDemo.Tests.Base;
using SauceDemo.Framework.Pages.Login;
using SauceDemo.Framework.Pages.Inventory;
using SauceDemo.Framework.Pages.Product;
using SauceDemo.Framework.TestData.Login;
using SauceDemo.Framework.Core.Enums;

namespace SauceDemo.Tests.Cart;

[TestFixture]
public sealed class CartTests : BaseTest
{
    [Test]
    [Category("UC-3")]
    [TestCaseSource(typeof(LoginTestData), nameof(LoginTestData.GetAddToCartCases))]
    public void AddProductToCart_ShouldUpdateShoppingCartBadge(
        BrowserType browserType,
        string username,
        string password,
        string productName,
        int expectedCartItemsCount)
    {
        var loginPage = new LoginPage(this.Driver, this.Settings.DefaultTimeoutSeconds);

        loginPage.Open(this.Settings.BaseUrl);
        InventoryPage inventoryPage = loginPage.LoginAs(username, password);

        ProductDetailsPage productDetailsPage = inventoryPage.OpenProductByName(productName);
        productDetailsPage.AddToCart();

        int actualCartItemsCount = productDetailsPage.Cart().GetItemsCount();

        actualCartItemsCount.Should().Be(expectedCartItemsCount);
    }
}