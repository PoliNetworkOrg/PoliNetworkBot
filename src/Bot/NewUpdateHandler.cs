using PoliNetwork.Telegram.Bot.Handler;
using Telegram.Bot;
using Telegram.Bot.Types;

class NewUpdateHandler : IUpdateHandler
{
    public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}