

using PoliNetwork.Telegram.Objects;

Console.WriteLine("Hello, starting Echo bot!");

var telegramBotWrapper = new TelegramBotWrapper("token");

while (true)
{
    telegramBotWrapper.CheckUpdatesAndRun();
}