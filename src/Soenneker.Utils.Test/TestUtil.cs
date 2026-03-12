using System.IO;
using Microsoft.Extensions.Configuration;

namespace Soenneker.Utils.Test;

/// <summary>
/// A utility library for useful test-based operations
/// </summary>
public static class TestUtil
{
    private const string DefaultAppSettings = "appsettings.json";

    /// <summary>
    /// Builds and returns an <see cref="IConfiguration"/> from appsettings.json in the current directory (optionally plus a child path if there are multiple appsettings needed)
    /// </summary>
    public static IConfiguration BuildConfig(
        string? childPath = null,
        string? fileName = null,
        string? environmentName = null)
    {
        string cwd = Directory.GetCurrentDirectory();

        string basePath = string.IsNullOrEmpty(childPath)
            ? cwd
            : Path.Combine(cwd, childPath);

        string settingsFile = string.IsNullOrEmpty(fileName)
            ? DefaultAppSettings
            : fileName;

        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile(settingsFile, optional: false, reloadOnChange: false);

        if (!string.IsNullOrEmpty(environmentName))
        {
            // e.g. appsettings.Development.json
            builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: false);
        }

        return builder.Build();
    }
}