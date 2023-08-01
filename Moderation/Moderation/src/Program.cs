#region

using PoliNetwork.Core.Data;
using PoliNetwork.Core.Utils;
using PoliNetwork.Core.Utils.LoggerNS;
using PoliNetwork.Db.Utils;
using PoliNetwork.Telegram.Objects.Bot;
using PoliNetwork.Telegram.Objects.Configuration;
using PoliNetwork.Telegram.Objects.Updates.Update;
using PoliNetwork.Telegram.Utils;
using PoliNetwork.Telegram.Utils.ConfigUtils;
using PoliNetwork.Telegram.Variables;

#endregion

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


    public static void Main(string[] args)
    {
        GlobalVariables.DefaultLogger.SetLogConfing(LogConfig);
        GlobalVariables.DefaultLogger.Info("Hello, starting Moderation bot!");
        var telegramConfig = TelegramConfigUtils.LoadOrInitializeConfig(Variables.DefaultConfigPath);
        if (telegramConfig == null)
        {
            GlobalVariables.DefaultLogger.Emergency("Telegram Config is undefined when starting the bot.");
            return;
        }

        telegramConfig.UpdateMethod = new UpdateMethod(UpdateAction);

        var dbConfig = DbConfigUtils.LoadOrInitializeConfig(PoliNetwork.Db.Variables.Variables.DefaultConfigPath);
        if (dbConfig == null)
        {
            GlobalVariables.DefaultLogger.Emergency("Database Config is undefined when starting the bot.");
            return;
        }

        _telegramBot = new TelegramBot(telegramConfig, LogConfig);
        _telegramBot.Start(new CancellationToken());
        Wait.WaitForever();
    }

    private static void UpdateAction(CancellationToken arg1, IUpdate arg2)
    {
        if (_telegramBot == null)
            return;


        // Only process Message updates: https://core.telegram.org/bots/api#message
        if (arg2.Message is not { } message)
            return;

        //Simply handle every message update with the "echo" method
        Echo.EchoMethod(
            message,
            _telegramBot, //we actually pass our bot object, not the one received from the caller
            arg1);
    }
}