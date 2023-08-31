using Telegram.Bot;
using Telegram.Bot.Types;

public interface IAUpdateHanlder
{
  Task Process(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
}