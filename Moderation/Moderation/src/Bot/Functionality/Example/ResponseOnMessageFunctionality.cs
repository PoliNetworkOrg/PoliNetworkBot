using PoliNetwork.Utility.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;
using PoliNetwork.Utility.MessageContentControl;

namespace PoliNetwork.Telegram.Bot.Functionality.Example
{
  public class ResponseOnMessageFunctionality : AbstractTelegramBotFunctionality
  {
    private static string[] CreateForbiddenWordsArray()
    {
      var path = Config.FORBIDDEN_WORDS;
      return JSONConverter.GetArrayFromFile(path) ?? Array.Empty<string>();
    }

    public override async Task RunAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
      /* This way we only process the message text part */
      if (update.Message is not { } message) return;
      if (message.Text is not { } messageText) return;

      var chatId = message.Chat.Id;
      var username = message.Chat.Username;

      var forbiddenWords = CreateForbiddenWordsArray();
      var HasForbiddenWord = new ForbiddenWordsController(forbiddenWords).ContainsForbiddenWord(messageText);

      var serverPrompt = $"Received a '{messageText}' message in chat {chatId} ({username}).";
      var responseText = HasForbiddenWord ? "Your massage contains a forbidden word" : "Your message is a valid one";
      Console.WriteLine(serverPrompt);

      var sentMessage = await bot.SendTextMessageAsync(
        chatId: chatId,
        text: responseText,
        cancellationToken: cancellationToken
      );

      serverPrompt = $"Sent message: {sentMessage.Text}";
      Console.WriteLine(serverPrompt);
    }
  }
}