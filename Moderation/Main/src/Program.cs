using PoliNetwork.Core.Utils;
using PoliNetwork.Telegram.Objects.Bot;
using PoliNetwork.Telegram.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Moderation;

internal static class Program
{
    private static TelegramBot? _telegramBot;

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (_telegramBot == null)
            return;

        // Only process Message updates: https://core.telegram.org/bots/api#message
        if (update.Message is not { } message)
            return;

        if (botClient.BotId != _telegramBot.GetId())
            return;

        //Simply handle every message update with the "echo" method
        await Echo.EchoMethod(message, _telegramBot, cancellationToken);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, starting Echo bot!");
        _telegramBot = new TelegramBot("token");
        _telegramBot.Start(HandleUpdateAsync);
        Wait.WaitForeverConsoleReadline();
    }
}