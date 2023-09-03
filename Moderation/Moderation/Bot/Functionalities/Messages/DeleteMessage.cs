#region

using System.Threading.Tasks;
using PoliNetwork.Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

#endregion

namespace PoliNetwork.Telegram.Bot.Functionalities.Messages;

internal static class DeleteMessage
{
    public static async Task DeleteIfMessageIsNotInPrivate(TelegramBot? telegramBotClient,
        Message? e)
    {
        if (e is { Chat.Type: ChatType.Private })
            return;

        try
        {
            if (telegramBotClient != null)
                if (e != null) {}
                    //await telegramBotClient.DeleteMessageAsync(e.Chat.Id, e.MessageId, null);
        }
        catch
        {
            // ignored
        }
    }

    internal static void TryDeleteMessagesAsync(MessageList? messages, TelegramBot? telegramBotClient)
    {
        if (telegramBotClient != null) messages?.TryDeleteMessagesAsync(telegramBotClient);
    }
}