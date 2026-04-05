using NUnit.Framework;

namespace SauceDemo.Framework.Web.Logging;

public static class TestLogger
{
    public static void Info(string message)
    {
        TestContext.Progress.WriteLine($"[{DateTime.Now:HH:mm:ss}] INFO: {message}");
    }

    public static void Error(string message)
    {
        TestContext.Progress.WriteLine($"[{DateTime.Now:HH:mm:ss}] ERROR: {message}");
    }

    public static void StartTest(string testName)
    {
        Info($"Test started: {testName}");
    }

    public static void EndTest(string testName)
    {
        Info($"Test finished: {testName}");
    }
}