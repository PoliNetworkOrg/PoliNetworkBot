#region

using PoliNetwork.Core.Data;
using PoliNetwork.Core.Utils;
using PoliNetwork.Core.Utils.LoggerNS;
using PoliNetwork.Telegram.Objects;
using PoliNetwork.Telegram.Objects.Bot;
using PoliNetwork.Telegram.Objects.Updates;
using PoliNetwork.Telegram.Utils.ConfigUtils;
using PoliNetwork.Telegram.Variables;

#endregion

namespace Echo;

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
        GlobalVariables.DefaultLogger.Info("Hello, starting Echo bot!");
        var telegramConfig = TelegramConfigUtils.LoadOrInitializeConfig(Variables.DefaultConfigPath);
        if (telegramConfig == null)
        {
            GlobalVariables.DefaultLogger.Emergency("Telegram Config is undefined when starting the bot.");
            return;
        }


        var updateMethod = new UpdateMethod(UpdateAction);
        _telegramBot = new TelegramBot(telegramConfig, updateMethod, LogConfig);
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
        PoliNetwork.Telegram.Utils.Echo.EchoMethod(
            message,
            _telegramBot, //we actually pass our bot object, not the one received from the caller
            arg1).Wait(arg1);
    }
}