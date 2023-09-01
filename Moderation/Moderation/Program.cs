using Configuration;
using PoliNetwork.Bot.Bot.Functionality.Example;
using PoliNetwork.Telegram.Bot;
using PoliNetwork.Telegram.Bot.Functionality;
using PoliNetwork.Telegram.Bot.Handler;
using PoliNetwork.Utility.ConfigurationLoader;

namespace PoliNetwork.Bot
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            List<ITelegramBotFunctionality> telegramBotFunctionalities = new()
            {
                new ResponseOnMessageFunctionality()
            };

            IUpdateHandler updateHandler = new DefaultUpdateHandler(telegramBotFunctionalities);
            IPollingErrorHandler pollingErrorHandler = new DefaultPollingErrorHandler();

            var botToken = new JSONConfigurationLoader().LoadConfiguration(GetBasePath() + Config.APP_SETTIGNS)
                .GetSection("Secrets:BotToken").Value!;
            TelegramBot bot = new(botToken);

            await bot.RunAsync(updateHandler, pollingErrorHandler);
        }

        public static string GetBasePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}