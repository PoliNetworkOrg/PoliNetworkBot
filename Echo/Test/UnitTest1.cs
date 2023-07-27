using NUnit.Framework.Internal;
using PoliNetwork.Telegram.Objects;
using PoliNetwork.Telegram.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EchoTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var telegramBotWrapper = new TelegramBot("token");
        telegramBotWrapper.Start((ITelegramBotClient botClient, Update update, CancellationToken cancellationToken) => { return Task.CompletedTask; });

        Assert.Pass();

    }
}