using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SauceDemoTests_Tsyhankov.Core.Config;

public sealed class TestSettings
{
    public string BaseUrl { get; init; } = string.Empty;

    public int DefaultTimeoutSeconds { get; init; }

    public bool Headless { get; init; }

    public static TestSettings Load()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        string baseUrl = configuration["BaseUrl"]
            ?? throw new InvalidOperationException("BaseUrl was not found in appsettings.json.");

        bool timeoutParsed = int.TryParse(configuration["DefaultTimeoutSeconds"], out int timeoutSeconds);
        bool headlessParsed = bool.TryParse(configuration["Headless"], out bool headless);

        return new TestSettings
        {
            BaseUrl = baseUrl,
            DefaultTimeoutSeconds = timeoutParsed ? timeoutSeconds : 10,
            Headless = headlessParsed && headless,
        };
    }
}
