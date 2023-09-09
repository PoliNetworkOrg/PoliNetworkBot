
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PoliNetwork.Telegram.Bot.Handler
{
    /// <summary>
    /// Represents an interface for handling incoming Telegram updates.
    /// </summary>
    public interface IUpdateHandler
    {
        /// <summary>
        /// Handles an incoming Telegram update asynchronously.
        /// </summary>
        /// <param name="botClient">The <see cref="ITelegramBotClient"/> instance used for interaction with the Telegram Bot API.</param>
        /// <param name="update">The <see cref="Update"/> representing the incoming update to be handled.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}
