using Configuration;
using PoliNetwork.Telegram.Bot.Functionality;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PoliNetwork.Bot.Bot.Functionality.Example
{
    public class ResponseOnMessageFunctionality : AbstractTelegramBotFunctionality
    {
        private static string GetBasePath()
        {
            return "C:/Users/Joe Biden/RiderProjects/PoliNetworkBot/Moderation/Moderation/";
        }

        private static string[] CreateForbiddenWordsArray()
        {
            var path = GetBasePath() + Config.FORBIDDEN_WORDS;
            return JSONConverter.GetArrayFromFile(path) ?? Array.Empty<string>();
        }

        public override async Task<Task> RunAsync(ITelegramBotClient bot, Update update,
            CancellationToken cancellationToken)
        {
            /* This way we only process the message text part */
            if (update.Message is not { } message) return Task.CompletedTask;
            if (message.Text is not { } messageText) return Task.CompletedTask;

            var chatId = message.Chat.Id;
            var username = message.Chat.Username;

            var forbiddenWords = CreateForbiddenWordsArray();
            var hasForbiddenWord = new ForbiddenWordsController(forbiddenWords).ContainsForbiddenWord(messageText);

            var serverPrompt = $"Received a '{messageText}' message in chat {chatId} ({username}).";
            var responseText =
                hasForbiddenWord ? "Your massage contains a forbidden word" : "Your message is a valid one";
            Console.WriteLine(serverPrompt);

            var sentMessage = await bot.SendTextMessageAsync(
                chatId: chatId,
                text: responseText,
                cancellationToken: cancellationToken
            );

            serverPrompt = $"Sent message: {sentMessage.Text}";
            Console.WriteLine(serverPrompt);

            return Task.CompletedTask;
        }
    }
}