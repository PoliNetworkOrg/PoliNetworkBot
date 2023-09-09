using Moderation.Bot.Handler;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace Moderation.Bot
{
  /// <summary>
  /// Represents a Telegram bot that can interact with the Telegram Bot API.
  /// </summary>
  public class TelegramBot : TelegramBotClient
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TelegramBot"/> class with the provided options and an optional HttpClient.
    /// </summary>
    /// <param name="options">The options specifying bot settings.</param>
    /// <param name="httpClient">Optional HttpClient to be used for API requests.</param>
    public TelegramBot(TelegramBotOptions options, HttpClient? httpClient = null)
        : base(options, httpClient) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="TelegramBot"/> class with the provided bot token and an optional HttpClient.
    /// </summary>
    /// <param name="token">The authentication token of the bot.</param>
    /// <param name="httpClient">Optional HttpClient to be used for API requests.</param>
    public TelegramBot(string token, HttpClient? httpClient = null)
        : base(token, httpClient) { }

    public async Task RunAsync(Handler.IUpdateHandler updateHandler, IPollingErrorHandler pollingErrorHandler)
    {
      using CancellationTokenSource cts = new();

      ReceiverOptions receiverOptions = new()
      {
        AllowedUpdates = Array.Empty<UpdateType>()
      };

      this.StartReceiving(
          updateHandler: updateHandler.HandleUpdateAsync,
          pollingErrorHandler: pollingErrorHandler.HandlePollingErrorAsync,
          receiverOptions: receiverOptions,
          cancellationToken: cts.Token
      );

      var me = await this.GetMeAsync();
      Console.WriteLine($"Start listening for @{me.Username}\nExit via typing");
      Console.ReadLine();
      cts.Cancel();
    }
  }
}

