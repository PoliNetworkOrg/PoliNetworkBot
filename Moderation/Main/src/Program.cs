using PoliNetwork.Core.Data;
using PoliNetwork.Core.Utils;
using PoliNetwork.Telegram.Logger;
using PoliNetwork.Db.Utils;
using PoliNetwork.Telegram.Objects.Bot;
using PoliNetwork.Telegram.Utils;
using PoliNetwork.Telegram.Utils.ConfigUtils;
using PoliNetwork.Telegram.Variables;
using Telegram.Bot;
using Telegram.Bot.Types;
using PoliNetwork.Core.Utils.LoggerNS;
using System.Configuration;

namespace Moderation;

internal static class Program
{
    private static AbstractTelegramBot? bot = null;
    private static AbstractLogger.LogConfiguration? loggerConfiguration = null;

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (bot == null
            || botClient.BotId != bot.BotId
            || update.Message is not { } message)
            return; // https://core.telegram.org/bots/api#message

        await Echo.EchoMethod(message, bot, cancellationToken);
    }

    public static void Main(string[] args)
    {

        // The PoliNetwork.Core.Utils.LoggerNS.Logger must extends the AbstractLogger so a sub class will be needed
        // The only dependency of the PoliNetwork.Core.Utils.LoggerNS.Logger resides here in the Program.cs 
        AbstractLogger? logger = null; // = new PoliNetwork.Core.Utils.LoggerNS.Logger();

        TelegramConfigUtils.FileConfigurationLoader fileConfigurationLoader = new TelegramConfigUtils.JSONFileConfigurationLoader();
        logger?.Info("Hello, starting Moderation bot!");
        var botConfiguration = fileConfigurationLoader.LoadOrInitializeConfig(Variables.DefaultConfigPath);
        var databaseConfiguration = DbConfigUtils.LoadOrInitializeConfig(PoliNetwork.Db.Variables.Variables.DefaultConfigPath);
        if (botConfiguration == null)
        {
            GlobalVariables.DefaultLogger.Emergency("Telegram Config is undefined when starting the bot.");
            return;
        }

        if (databaseConfiguration == null)
        {
            GlobalVariables.DefaultLogger.Emergency("Database Config is undefined when starting the bot.");
            return;
        }

        // TelegramConfiguration should extends TelegramBotClientOptions 
        TelegramBotClientOptions options = new(botConfiguration.Token, botConfiguration.BaseUrl);
        bot = new ModerationBot(options: options, logger: logger);
        bot.Start(HandleUpdateAsync);
        Wait.WaitForever();
    }
}