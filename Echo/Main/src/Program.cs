
using PoliNetwork.Telegram.Objects;
using PoliNetwork.Telegram.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;


Console.WriteLine("Hello, starting Echo bot!");

var telegramBotWrapper = new TelegramBot("token");

telegramBotWrapper.Start(HandleUpdateAsync);
while (true)
{
    Console.ReadLine();
}

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Message is not { } message)
        return;

    await Echo.EchoMethod(message, botClient, cancellationToken);
}
