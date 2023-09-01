using PoliNetwork.Telegram.Bot.Functionality;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PoliNetwork.Telegram.Bot.Handler
{
  public class DefaultUpdateHandler : IUpdateHandler
  {
    private readonly List<ITelegramBotFunctionality> _functionalities;

    public DefaultUpdateHandler(List<ITelegramBotFunctionality> functionalities)
    {
      _functionalities = functionalities;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
      /* Parallel.ForEach(_functionalities, functionalities => functionalities.Run(botClient, update, cancellationToken)); */
      foreach (var functionality in _functionalities)
      {
        await functionality.RunAsync(botClient, update, cancellationToken);
      }
    }

    public List<ITelegramBotFunctionality> GetFunctionalitisList() => _functionalities;
  }
}