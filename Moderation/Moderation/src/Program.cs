using Moderation.Bot.Functionality.Example;
using PoliNetwork.Telegram.Bot;
using PoliNetwork.Telegram.Bot.Functionality;
using PoliNetwork.Telegram.Bot.Handler;
using PoliNetwork.Utility.ConfigurationLoader;
using PoliNetwork.Utility.Configuration;

namespace PoliNetwork.Moderation
{
    internal abstract class Program
    {
        private static async Task Main()
        {
            List<ITelegramBotFunctionality> telegramBotFunctionalities = new()
            {
                new ResponseOnMessageFunctionality()
            };

            IUpdateHandler updateHandler = new DefaultUpdateHandler(telegramBotFunctionalities);
            IPollingErrorHandler pollingErrorHandler = new DefaultPollingErrorHandler();

            var botToken = new JSONConfigurationLoader().LoadConfiguration(Config.APP_SETTINGS)
                .GetSection("Secrets:BotToken").Value!;
            TelegramBot bot = new(botToken);

            await bot.RunAsync(updateHandler, pollingErrorHandler);
        }
        
    }
    
    public class HelloWorld
    {
        public string SayHello()
        {
            return "Hello, World!";
        }
    }
}