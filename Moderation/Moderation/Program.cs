using Configuration;
using PoliNetwork.Telegram.Bot;
using PoliNetwork.Telegram.Bot.Functionality;
using PoliNetwork.Telegram.Bot.Handler;
using PoliNetwork.Utility.ConfigurationLoader;

namespace Telegram
{
  internal class Program
  {
    private static async Task Main(string[] args)
    {
      List<ITelegramBotFunctionality> telegramBotFunctionalities = new() {
        new ResponseOnMessageFunctionality()
      };

      IUpdateHandler updateHandler = new DefaultUpdateHandler(telegramBotFunctionalities);
      IPollingErrorHandler pollingErrorHandler = new DefaultPollingErrorHandler();

      string botToken = new JSONConfigurationLoader().LoadConfiguration(Config.APP_SETTIGNS).GetSection("Secrets:BotToken").Value!;
      TelegramBot bot = new(botToken)!;

      await bot.RunAsync(updateHandler, pollingErrorHandler);
    }
  }
}