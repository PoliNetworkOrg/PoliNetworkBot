using Moderation.Bot.Functionality.Generic;
using Moderation.Utility.Converter;
using Moderation.Utility.MessageContentControl;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Moderation.Bot.Functionality.Implementations
{
  public class CheckIfMessageIsSpam : AbstractTelegramBotFunctionality
  {
    public override async Task RunAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
      // check if message is user is admin or global admin
      // check if message is spam
      // if message is spam, delete it
      
    }
  }
}