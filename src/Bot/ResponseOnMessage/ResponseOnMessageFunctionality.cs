using Telegram.Bot;
using PoliNetwork.Telegram.Bot.Handler;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace PoliNetwork.Telegram.Bot.Functionality
{
  class ResponseOnMessageFunctionality : AbstractTelegramBotFunctionality
  {
    public ResponseOnMessageFunctionality(Handler.IUpdateHandler updateHandler, IPollingErrorHandler pollingErrorHandler)
    : base(updateHandler, pollingErrorHandler) { }

    public override async Task Run(TelegramBot botClient)
    {
      using CancellationTokenSource cts = new();

      ReceiverOptions receiverOptions = new()
      {
        AllowedUpdates = Array.Empty<UpdateType>()
      };

      botClient.StartReceiving(
          updateHandler: _updateHandler.HandleUpdateAsync,
          pollingErrorHandler: _pollingErrorHandler.HandlePollingErrorAsync,
          receiverOptions: receiverOptions,
          cancellationToken: cts.Token
      );

      var me = await botClient.GetMeAsync();

      Console.WriteLine($"Start listening for @{me.Username}\nExit via typing");
      Console.ReadLine();

      cts.Cancel();
    }
  }
}