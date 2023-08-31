using Telegram.Bot;

namespace PoliNetwork.Telegram.Bot
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
  }
}
