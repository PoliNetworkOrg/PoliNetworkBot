using PoliNetwork.Telegram.Objects.Bot;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ModerationTest.Tests;

public class Tests
{
    private static Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void StartBot()
    {
        var telegramBotWrapper = new TestBot();
        telegramBotWrapper.Start(HandleUpdateAsync);
        Assert.Pass();
    }
}