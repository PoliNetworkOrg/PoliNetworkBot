using PoliNetwork.Telegram.Bot.Bots;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Moderation.Bot.Functionality.Generic
{
  /// <summary>
  /// Represents an abstract base class for defining the functionality of a Telegram bot.
  /// </summary>
  public abstract class AbstractTelegramBotFunctionality : ITelegramBotFunctionality
  {
    /// <summary>
    /// Defines the behavior of the bot's functionality. This method must be implemented by derived classes.
    /// </summary>
    /// <param name="bot">The <see cref="TelegramBot"/> instance representing the bot with which the functionality is associated.</param>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public abstract Task RunAsync(AbstractTelegramBot bot, Update update, CancellationToken cancellationToken);  }
}
