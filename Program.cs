using Configuration;
using PoliNetwork.Telegram.Bot;
using PoliNetwork.Telegram.Bot.Functionality;
using PoliNetwork.Telegram.Bot.Handler;
using PoliNetwork.Utility.ConfigurationLoader;
using Telegram.Bot.Functionality;

namespace Telegram
{
  internal class Program
  {
    private static async Task Main(string[] args)
    {
      IUpdateHandler updateHandler = new ResponseOnMessageUpdateHandler();
      IPollingErrorHandler pollingErrorHandler = new ResponseOnPollingErrorHandler();
      ITelegramBotFunctionality sendResponseOnReceivedMessage = new ResponseOnMessageFunctionality(updateHandler, pollingErrorHandler);

      string botToken = new JSONConfigurationLoader().LoadConfiguration(Config.APP_SETTIGNS).GetSection("Secrets:BotToken").Value!;
      TelegramBot bot = new(botToken)!;

      await sendResponseOnReceivedMessage.Run(bot);
    }
  }
}