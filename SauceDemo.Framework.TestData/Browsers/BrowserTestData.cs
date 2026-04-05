using SauceDemo.Framework.Core.Enums;

namespace SauceDemo.Framework.TestData.Browsers;

public static class BrowserTestData
{
    public static IEnumerable<BrowserType> GetAllBrowsers()
    {
        yield return BrowserType.Firefox;
        yield return BrowserType.Edge;
    }
}