using PoliNetwork.Telegram.Bot.Functionality;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PoliNetwork.Telegram.Bot.Handler
{
  public class DefaultUpdateHandler : IUpdateHandler
  {
    private readonly List<ITelegramBotFunctionality> Functionalities; 

    public DefaultUpdateHandler(List<ITelegramBotFunctionality> functionalities)
    {
      Functionalities = functionalities;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
      /* Parallel.ForEach(_functionalities, functionalities => functionalities.Run(botClient, update, cancellationToken)); */
      foreach (var functionality in Functionalities)
      {
        await functionality.RunAsync(botClient, update, cancellationToken);
      }
    }
  }
}