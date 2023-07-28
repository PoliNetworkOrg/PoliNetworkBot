using PoliNetwork.Core.Data;
using PoliNetwork.Core.Utils;
using PoliNetwork.Core.Utils.LoggerNS;
using PoliNetwork.Telegram.Objects.Bot;
using PoliNetwork.Telegram.Objects.Configuration;
using PoliNetwork.Telegram.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Moderation;

internal static class Program
{
    /// <summary>
    ///     Telegram bot
    /// </summary>
    private static TelegramBot? _telegramBot;

    /// <summary>
    ///     Default log config
    /// </summary>
    private static readonly LogConfig LogConfig = new();

    /// <summary>
    ///     Main
    /// </summary>
    /// <param name="args">args</param>
    public static void Main(string[] args)
    {
        GlobalVariables.DefaultLogger.SetLogConfing(LogConfig);
        GlobalVariables.DefaultLogger.Info("Hello, starting Moderation bot!");
        _telegramBot = new TelegramBot(new TelegramConfig { Token = "token" }, LogConfig);
        _telegramBot.Start(HandleUpdateAsync);
        Wait.WaitForever();
    }

    /// <summary>
    ///     Handle updates
    /// </summary>
    /// <param name="botClient">botClient</param>
    /// <param name="update">update</param>
    /// <param name="cancellationToken">cancellationToken</param>
    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (_telegramBot == null)
            return;

        // Safe check to see if the bot we have is actually the one generating the update
        if (botClient.BotId != _telegramBot.GetId())
            return;

        // Only process Message updates: https://core.telegram.org/bots/api#message
        if (update.Message is not { } message)
            return;

        //Simply handle every message update with the "echo" method
        await Echo.EchoMethod(
            message,
            _telegramBot, //we actually pass our bot object, not the one received from the caller
            cancellationToken);
    }
}