using Moderation.Bot;
using Moderation.Bot.Functionality;
using Moderation.Bot.Functionality.Generic;
using Moderation.Bot.Functionality.Implementations.Example;
using Moderation.Bot.Handler;
using Moderation.Bot.Handler.Default;
using Moderation.Utility.ConfigurationLoad;

namespace Moderation
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
}