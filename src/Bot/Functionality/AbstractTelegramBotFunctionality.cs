using PoliNetwork.Telegram.Bot.Handler;
using Telegram.Bot.Functionality;

namespace PoliNetwork.Telegram.Bot.Functionality
{
  /// <summary>
  /// Represents an abstract base class for defining the functionality of a Telegram bot.
  /// </summary>
  public abstract class AbstractTelegramBotFunctionality : ITelegramBotFunctionality
  {
    protected readonly IUpdateHandler _updateHandler;
    protected readonly IPollingErrorHandler _pollingErrorHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="AbstractTelegramBotFunctionality"/> class.
    /// </summary>
    /// <param name="updateHandler">An instance of <see cref="IUpdateHandler"/> for handling incoming updates.</param>
    /// <param name="pollingErrorHandler">An instance of <see cref="IPollingErrorHandler"/> for handling polling errors.</param>
    public AbstractTelegramBotFunctionality(IUpdateHandler updateHandler, IPollingErrorHandler pollingErrorHandler)
    {
      _updateHandler = updateHandler;
      _pollingErrorHandler = pollingErrorHandler;
    }

    /// <summary>
    /// Defines the behavior of the bot's functionality. This method must be implemented by derived classes.
    /// </summary>
    /// <param name="bot">The <see cref="TelegramBot"/> instance representing the bot with which the functionality is associated.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public abstract Task Run(TelegramBot bot);
  }
}
