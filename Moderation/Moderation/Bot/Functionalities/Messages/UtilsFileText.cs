#region

using System.IO;
using PoliNetwork.Common.Enums;

#endregion

namespace PoliNetwork.Telegram.Bot.Functionalities.Messages;

internal static class UtilsFileText
{
    internal static TelegramFile GenerateFileFromString(string data, string fileName, Language? caption,
        TextAsCaption textAsCaption,
        string? mimeType = "application/json")
    {
        var stream = GenerateStreamFromString(data);
        var telegramFile = new TelegramFile(stream, fileName, caption, mimeType, textAsCaption);
        return telegramFile;
    }

    public static Stream GenerateStreamFromString(string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}