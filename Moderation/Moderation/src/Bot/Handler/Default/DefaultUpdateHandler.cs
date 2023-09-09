using Moderation.Bot.Functionality;
using Moderation.Bot.Functionality.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Moderation.Bot.Handler.Default
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