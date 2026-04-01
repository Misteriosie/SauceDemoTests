using FluentAssertions;
using NUnit.Framework;
using SauceDemoTests_Tsyhankov.Core.Base;
using SauceDemoTests_Tsyhankov.Core.Driver;
using SauceDemoTests_Tsyhankov.Pages;
using SauceDemoTests_Tsyhankov.TestData;

namespace SauceDemoTests_Tsyhankov.Tests;

[TestFixture]
public sealed class LoginTests : BaseTest
{
    [Test]
    [Category("UC-1")]
    [TestCaseSource(typeof(LoginTestData), nameof(LoginTestData.GetMissingPasswordCases))]
    public void Login_WithOnlyUsernameProvided_ShouldShowPasswordRequiredError(
        BrowserType browserType,
        string username,
        string passwordToClear,
        string expectedErrorMessage)
    {
        var loginPage = new LoginPage(this.Driver, this.Settings.DefaultTimeoutSeconds);

        loginPage.Open(this.Settings.BaseUrl);
        loginPage.EnterUsername(username);
        loginPage.EnterPassword(passwordToClear);
        loginPage.ClearPassword();
        loginPage.ClickLogin();

        string actualErrorMessage = loginPage.GetErrorMessage();

        actualErrorMessage.Should().Contain(expectedErrorMessage);
    }

    [Test]
    [Category("UC-2")]
    [TestCaseSource(typeof(LoginTestData), nameof(LoginTestData.GetValidLoginCases))]
    public void Login_WithValidCredentials_ShouldOpenInventoryPage(
        BrowserType browserType,
        string username,
        string password)
    {
        var loginPage = new LoginPage(this.Driver, this.Settings.DefaultTimeoutSeconds);

        loginPage.Open(this.Settings.BaseUrl);
        InventoryPage inventoryPage = loginPage.LoginAs(username, password);

        inventoryPage.IsBurgerMenuDisplayed().Should().BeTrue();
        inventoryPage.IsAppLogoDisplayed().Should().BeTrue();
        inventoryPage.GetAppLogoText().Should().Be("Swag Labs");
        inventoryPage.IsShoppingCartDisplayed().Should().BeTrue();
        inventoryPage.IsSortDropdownDisplayed().Should().BeTrue();
        inventoryPage.GetInventoryItemsCount().Should().BeGreaterThan(0);
    }
}