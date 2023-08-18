#region 
using PoliNetwork.Core.Utils;
using PoliNetwork.Telegram.Logger;
using PoliNetwork.Db.Utils;
using PoliNetwork.Telegram.Bot;
using PoliNetwork.Telegram.Configuration;
using PoliNetwork.Telegram.ConfigurationLoader;
using PoliNetwork.Db.Objects;
using PoliNetwork.Telegram.Bot.Bots;
using PoliNetwork.Telegram.Options;
using PoliNetwork.Telegram.Properties;
#endregion 

namespace Moderation;

internal static class Program
{
    private static ModerationBot? bot = null;
    private static readonly string databaseConfigurationPath = "";

    public static void Main()
    {
        /* The PoliNetwork.Core.Utils.LoggerNS.Logger must extends the AbstractLogger so a sub class will be needed
        The only dependency of the PoliNetwork.Core.Utils.LoggerNS.Logger resides here in the Program.cs  */
        AbstractLogger? logger = new DefaultLogger();
        FileConfigurationLoader fileConfigurationLoader = new JSONFileConfigurationLoader();
        AbstractTelegramBotOptions? botConfiguration = fileConfigurationLoader.LoadOrInitializeConfig(Configuration.TELEGRAM_CONFIGURATION_PATH, logger);

        DbConfig? databaseConfiguration = DbConfigUtils.LoadOrInitializeConfig(databaseConfigurationPath);
        if (botConfiguration == null)
        {
            logger?.Emergency("Telegram Config is undefined when starting the bot.");
            return;
        }

        if (databaseConfiguration == null)
        {
            logger?.Emergency("Database Config is undefined when starting the bot.");
            return;
        }

        logger?.Info("RUNNING MODERATION BOT");
        botConfiguration.UpdateMethod = new UpdateMethod(UpdateAction);

        /* TelegramConfiguration should extends TelegramBotClientOptions */
        bot = new ModerationBot(options: botConfiguration, logger: logger);
        bot.Start(new CancellationToken());
        Wait.WaitForever();
    }

    private static void UpdateAction(CancellationToken cancellationToken, IUpdate update)
    {
        /* Process Message updates only, see: https://core.telegram.org/bots/api#message */
        if (bot == null || update.Message is not { } message) return;
        bot.Echo(message, cancellationToken);
    }
}