using SauceDemoTests_Tsyhankov.Core.Driver;

namespace SauceDemoTests_Tsyhankov.TestData;

public static class BrowserTestData
{
    public static IEnumerable<BrowserType> GetAllBrowsers()
    {
        yield return BrowserType.Firefox;
        yield return BrowserType.Edge;
    }
}