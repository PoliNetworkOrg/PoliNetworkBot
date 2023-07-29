using PoliNetwork.Core.Data;
using PoliNetwork.Core.Utils;
using PoliNetwork.Core.Utils.LoggerNS;
using PoliNetwork.Db.Utils;
using PoliNetwork.Telegram.Objects.Bot;
using PoliNetwork.Telegram.Utils;
using PoliNetwork.Telegram.Utils.ConfigUtils;
using PoliNetwork.Telegram.Variables;
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
    ///     Handle updates
    /// </summary>
    /// <param name="botClient">botClient</param>
    /// <param name="update">update</param>
    /// <param name="cancellationToken">cancellationToken</param>
    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (_telegramBot == null
            || botClient.BotId != _telegramBot.GetId()
            || update.Message is not { } message)
            return; // https://core.telegram.org/bots/api#message

        await Echo.EchoMethod(message, _telegramBot, cancellationToken);
    }

    public static void Main(string[] args)
    {
        GlobalVariables.DefaultLogger.SetLogConfing(LogConfig);
        GlobalVariables.DefaultLogger.Info("Hello, starting Moderation bot!");
        var telegramConfig = TelegramConfigUtils.LoadOrInitializeConfig(Variables.DefaultConfigPath);
        var dbConfig = DbConfigUtils.LoadOrInitializeConfig(PoliNetwork.Db.Variables.Variables.DefaultConfigPath);
        if (telegramConfig == null)
        {
            GlobalVariables.DefaultLogger.Emergency("Telegram Config is undefined when starting the bot.");
            return;
        }

        if (dbConfig == null)
        {
            GlobalVariables.DefaultLogger.Emergency("Database Config is undefined when starting the bot.");
            return;
        }

        _telegramBot = new TelegramBot(telegramConfig, LogConfig);
        _telegramBot.Start(HandleUpdateAsync);
        Wait.WaitForever();
    }
}