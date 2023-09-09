using Telegram.Bot;

namespace Moderation.Bot.Handler
{
    /// <summary>
    /// Represents an interface for handling errors that occur during the polling process of a Telegram bot.
    /// </summary>
    public interface IPollingErrorHandler
    {
        /// <summary>
        /// Handles a polling error asynchronously.
        /// </summary>
        /// <param name="botClient">The <see cref="ITelegramBotClient"/> instance used for interaction with the Telegram Bot API.</param>
        /// <param name="exception">The <see cref="Exception"/> that occurred during the polling process.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken);
    }
}
