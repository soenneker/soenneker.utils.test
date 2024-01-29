using System.IO;
using Microsoft.Extensions.Configuration;

namespace Soenneker.Utils.Test;

/// <summary>
/// A utility library for useful test-based operations
/// </summary>
public class TestUtil
{
    /// <summary>
    /// Builds and returns an <see cref="IConfiguration"/> from appsettings.json in the current directory (optionally plus a child path if there are multiple appsettings needed)
    /// </summary>
    public static IConfiguration BuildConfig(string? childPath = null, string? fileName = null)
    {
        string directory;
        
        if (childPath != null)
            directory = Path.Combine(Directory.GetCurrentDirectory(), childPath);
        else
            directory = Directory.GetCurrentDirectory();

        string baseAppSettings = fileName ?? "appsettings.json";

        string? environmentAppSettings = null;

        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile(baseAppSettings);

        if (environmentAppSettings != null)
            builder.AddJsonFile(environmentAppSettings);

        IConfiguration configRoot = builder.Build();

        return configRoot;
    }
}