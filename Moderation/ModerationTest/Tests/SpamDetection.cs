using System.Collections.Generic;
using System.Threading.Tasks;
using Moderation.Utility.SpamDetection;

namespace ModerationTest.Tests;

public class SpamDetection
{
    [Fact]
    public async Task TestIsForbiddenWordAsync_WithForbiddenWords_ReturnsTrue()
    {
        // Arrange
        ForbiddenWordsDetection.ForbiddenData = new ForbiddenData(new List<string> { "badword", "forbidden" });

        // Act
        bool result1 = await ForbiddenWordsDetection.IsForbiddenWordAsync("This is a badword.");
        bool result2 = await ForbiddenWordsDetection.IsForbiddenWordAsync("This is a forbidden word.");

        // Assert
        Assert.True(result1);
        Assert.True(result2);
    }

    [Fact]
    public async Task TestIsForbiddenWordAsync_WithoutForbiddenWords_ReturnsFalse()
    {
        // Arrange
        ForbiddenWordsDetection.ForbiddenData = new ForbiddenData();

        // Act
        bool result = await ForbiddenWordsDetection.IsForbiddenWordAsync("This is a safe word.");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task TestIsForbiddenLink_WithForbiddenDomain_ReturnsTrue()
    {
        // Arrange
        ForbiddenWordsDetection.ForbiddenData = new ForbiddenData(forbiddenDomains: new List<string> { "bad.com", "evil.org" });

        // Act
        bool result1 = await ForbiddenWordsDetection.IsForbiddenLink("https://www.bad.com");
        bool result2 = await ForbiddenWordsDetection.IsForbiddenLink("https://evil.org/path");

        // Assert
        Assert.True(result1);
        Assert.True(result2);
    }

    [Fact]
    public async Task TestIsForbiddenLink_WithoutForbiddenDomain_ReturnsFalse()
    {
        // Arrange
        ForbiddenWordsDetection.ForbiddenData = new ForbiddenData();

        // Act
        bool result = await ForbiddenWordsDetection.IsForbiddenLink("https://www.safe.com");

        // Assert
        Assert.False(result);
    }
}