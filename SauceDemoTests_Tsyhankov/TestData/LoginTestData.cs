using NUnit.Framework;
using SauceDemoTests_Tsyhankov.Core.Driver;

namespace SauceDemoTests_Tsyhankov.TestData;

public static class LoginTestData
{
    public static IEnumerable<TestCaseData> GetMissingPasswordCases()
    {
        foreach (BrowserType browser in BrowserTestData.GetAllBrowsers())
        {
            yield return new TestCaseData(
                    browser,
                    "standard_user",
                    "secret_sauce",
                    "Password is required")
                .SetName($"UC1_Login_WithOnlyUsername_ShouldShowPasswordRequired_{browser}");
        }
    }

    public static IEnumerable<TestCaseData> GetValidLoginCases()
    {
        foreach (BrowserType browser in BrowserTestData.GetAllBrowsers())
        {
            yield return new TestCaseData(
                    browser,
                    "standard_user",
                    "secret_sauce")
                .SetName($"UC2_Login_WithValidCredentials_ShouldOpenInventory_{browser}");
        }
    }

    public static IEnumerable<TestCaseData> GetAddToCartCases()
    {
        foreach (BrowserType browser in BrowserTestData.GetAllBrowsers())
        {
            yield return new TestCaseData(
                    browser,
                    "standard_user",
                    "secret_sauce",
                    "Sauce Labs Backpack",
                    1)
                .SetName($"UC3_AddProductToCart_ShouldUpdateCartBadge_{browser}");
        }
    }
}