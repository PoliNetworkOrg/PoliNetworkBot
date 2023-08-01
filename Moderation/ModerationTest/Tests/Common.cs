using System.Threading;
using Moderation;
using PoliNetwork.Telegram.Objects.Bot;

namespace ModerationTest.Tests
{
    public class Tests
    {
        public Tests()
        {
            // Setup code here, if needed
        }

        [Fact]
        public void StartBot()
        {
            var telegramBotWrapper = new TestBot();
            telegramBotWrapper.Start(new CancellationToken());

            // Assert something here, if applicable.
            // xUnit doesn't have an equivalent to NUnit's Assert.Pass().
            // Your test will pass as long as it doesn't throw an exception.
        }
    }
    public class HelloWorldTests
    {
        [Fact]
        public void TestSayHello()
        {
            // Arrange
            HelloWorld helloWorld = new HelloWorld();

            // Act
            string result = helloWorld.SayHello();

            // Assert
            Assert.Equal("Hello, World!", result);
        }
    }
}