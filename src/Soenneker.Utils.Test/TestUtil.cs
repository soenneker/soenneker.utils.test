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
    /// Builds configuration from a required JSON file beneath the current working directory and an optional environment-specific overlay.
    /// </summary>
    /// <param name="childPath">An optional path appended to the current working directory.</param>
    /// <param name="fileName">The required base settings filename. Defaults to <c>appsettings.json</c>.</param>
    /// <param name="environmentName">An optional environment name used to load <c>appsettings.{Environment}.json</c> after the base file.</param>
    /// <returns>The built configuration with environment-specific values overriding base values.</returns>
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
