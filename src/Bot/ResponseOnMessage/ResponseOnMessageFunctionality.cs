using Telegram.Bot;
using PoliNetwork.Telegram.Bot.Handler;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;

namespace PoliNetwork.Telegram.Bot.Functionality
{
  class ResponseOnMessageFunctionality : AbstractTelegramBotFunctionality

  {

    public IAUpdateHanlder AupdateHanlder;
    public ResponseOnMessageFunctionality(Handler.IUpdateHandler updateHandler, IPollingErrorHandler pollingErrorHandler, IAUpdateHanlder aupdateHanlder)
    : base(updateHandler, pollingErrorHandler)
    {
      AupdateHanlder = aupdateHanlder;
    }

    public override async Task Run(TelegramBot botClient)
    {
      using CancellationTokenSource cts = new();

      ReceiverOptions receiverOptions = new()
      {
        AllowedUpdates = Array.Empty<UpdateType>()
      };

      botClient.StartReceiving(
          updateHandler: (a, b, c) =>
          {
            return AupdateHanlder.Process(a, b, c); // :( non ho voglia
          },
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