using Telegram.Bot;

namespace PoliNetwork.Telegram.Bot
{
  /// <summary>
  /// Represents options for configuring a <see cref="TelegramBot"/>.
  /// </summary>
  public class TelegramBotOptions : TelegramBotClientOptions
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TelegramBotOptions"/> class with the provided token, base URL, and test environment settings.
    /// </summary>
    /// <param name="token">The authentication token of the bot.</param>
    /// <param name="baseUrl">Optional base URL for API requests.</param>
    /// <param name="useTestEnvironment">Flag indicating whether to use the test environment.</param>
    protected TelegramBotOptions(string token, string? baseUrl = null, bool useTestEnvironment = false)
        : base(token, baseUrl, useTestEnvironment) { }
  }
}
