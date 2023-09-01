using Telegram.Bot;
using Telegram.Bot.Types;

class Example : IAUpdateHanlder
{
    public async Task Process(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        /* This way we only process the message text part */
        if (update.Message is not { } message) return;
        if (message.Text is not { } messageText) return;

        long chatId = message.Chat.Id;
        string? username = message.Chat.Username;

        string[] forbiddenWords = CreateForbiddenWordsArray();
        bool HasForbiddenWord = new ForbiddenWordsController(forbiddenWords).ContainsForbiddenWord(messageText);

        string serverPrompt = $"Received a '{messageText}' message in chat {chatId} ({username}).";
        string responseText = HasForbiddenWord ? "Your massage contains a forbidden word" : "Your message is a valid one";
        Console.WriteLine(serverPrompt);

        var sentMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: responseText,
            cancellationToken: cancellationToken
        );

        serverPrompt = $"Sent message: {sentMessage.Text}";
        Console.WriteLine(serverPrompt);
    }

    private static string[] CreateForbiddenWordsArray()
    {
        string path = @"./persistence/forbidden_words.json";
        return JSONConverter.GetArrayFromFile(path) ?? Array.Empty<string>();
    }
}