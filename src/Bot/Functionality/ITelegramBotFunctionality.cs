using Telegram.Bot;
using Telegram.Bot.Types;

namespace PoliNetwork.Telegram.Bot.Functionality
{
  /// <summary>
  /// Represents an interface for defining the functionality of a Telegram bot.
  /// </summary>
  public interface ITelegramBotFunctionality
  {
    /// <summary>
    /// Runs the defined functionality using the provided <see cref="TelegramBot"/>.
    /// </summary>
    /// <param name="bot">The <see cref="TelegramBot"/> instance representing the bot with which the functionality is associated.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task RunAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken);
  }
}
