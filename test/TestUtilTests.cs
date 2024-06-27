using System.IO;
using FluentAssertions;
using Moq;
using Soenneker.Utils.Test.Tests.Dtos.Abstract;
using Xunit;

namespace Soenneker.Utils.Test.Tests;

public class TestUtilTests
{
    [Fact]
    public void BuildConfig_ShouldReturnConfiguration_WhenNoParametersProvided()
    {
        // Arrange
        var currentDirectory = Directory.GetCurrentDirectory();
        var baseAppSettings = "appsettings.json";
        var filePath = Path.Combine(currentDirectory, baseAppSettings);

        // Mock file existence
        var fileMock = new Mock<IFile>();
        fileMock.Setup(f => f.Exists(filePath)).Returns(true);

        // Act
        var config = TestUtil.BuildConfig();

        // Assert
        config.Should().NotBeNull();
        config["SomeKey"].Should().NotBeNull(); // Check for a known key in the appsettings.json
    }

    [Fact]
    public void BuildConfig_ShouldReturnConfiguration_WhenChildPathProvided()
    {
        // Arrange
        var currentDirectory = Directory.GetCurrentDirectory();
        var childPath = "config";
        var combinedPath = Path.Combine(currentDirectory, childPath);
        var baseAppSettings = "appsettings.json";
        var filePath = Path.Combine(combinedPath, baseAppSettings);

        // Mock file existence
        var fileMock = new Mock<IFile>();
        fileMock.Setup(f => f.Exists(filePath)).Returns(true);

        // Act
        var config = TestUtil.BuildConfig(childPath);

        // Assert
        config.Should().NotBeNull();
        config["SomeKey"].Should().NotBeNull(); // Check for a known key in the appsettings.json
    }

    [Fact]
    public void BuildConfig_ShouldReturnConfiguration_WhenFileNameProvided()
    {
        // Arrange
        var currentDirectory = Directory.GetCurrentDirectory();
        var fileName = "customsettings.json";
        var filePath = Path.Combine(currentDirectory, fileName);

        // Mock file existence
        var fileMock = new Mock<IFile>();
        fileMock.Setup(f => f.Exists(filePath)).Returns(true);

        // Act
        var config = TestUtil.BuildConfig(fileName: fileName);

        // Assert
        config.Should().NotBeNull();
        config["SomeKey"].Should().NotBeNull(); // Check for a known key in the customsettings.json
    }

    [Fact]
    public void BuildConfig_ShouldReturnConfiguration_WhenChildPathAndFileNameProvided()
    {
        // Arrange
        var currentDirectory = Directory.GetCurrentDirectory();
        var childPath = "config";
        var fileName = "customsettings.json";
        var combinedPath = Path.Combine(currentDirectory, childPath);
        var filePath = Path.Combine(combinedPath, fileName);

        // Mock file existence
        var fileMock = new Mock<IFile>();
        fileMock.Setup(f => f.Exists(filePath)).Returns(true);

        // Act
        var config = TestUtil.BuildConfig(childPath, fileName);

        // Assert
        config.Should().NotBeNull();
        config["SomeKey"].Should().NotBeNull(); // Check for a known key in the customsettings.json
    }
}