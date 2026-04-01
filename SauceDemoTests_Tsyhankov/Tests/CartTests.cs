using FluentAssertions;
using NUnit.Framework;
using SauceDemoTests_Tsyhankov.Core.Base;
using SauceDemoTests_Tsyhankov.Core.Driver;
using SauceDemoTests_Tsyhankov.Pages;
using SauceDemoTests_Tsyhankov.TestData;

namespace SauceDemoTests_Tsyhankov.Tests;

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