using Telegram.Bot;
using Telegram.Bot.Exceptions;

namespace PoliNetwork.Telegram.Bot.Handler
{
  public class ResponseOnPollingErrorHandler : IPollingErrorHandler
  {
    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
      var ErrorMessage = exception switch
      {
        ApiRequestException apiRequestException
          => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
      };

      Console.WriteLine(ErrorMessage);
      return Task.CompletedTask;
    }
  }
}