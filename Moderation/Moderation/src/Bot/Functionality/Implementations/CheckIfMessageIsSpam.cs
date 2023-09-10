using System.Net;
using Moderation.Bot.Functionality.Generic;
using Moderation.Utility.Converter;
using Moderation.Utility.MessageContentControl;
using Moderation.Utility.SpamDetection;
using Newtonsoft.Json;
using PoliNetwork.Telegram.Bot.Bots;
using PoliNetwork.Telegram.Bot.Functionality;
using PoliNetwork.Telegram.Utility.Logger;
using Telegram.Bot;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace Moderation.Bot.Functionality.Implementations
{
  public class CheckIfMessageIsSpam : AbstractTelegramBotFunctionality
  {
    public AdminUtils.RoleData RoleData { get; set; } = LoadRoleData();

    private static AdminUtils.RoleData LoadRoleData()
    {
      var path = Config.ROLES_DATA;
      AdminUtils.RoleData? roleDataRaw = null;
      try
      {
        roleDataRaw = JsonConvert.DeserializeObject<AdminUtils.RoleData>(File.ReadAllText(path));
      }
      catch (Exception e)
      {
        var logger = new DefaultLogger();
        logger.Error("Got an exception while trying to deserialize object in ForbiddenWordsDetection");
        logger.Error(e);
      }
      var forbiddenData = roleDataRaw ?? new AdminUtils.RoleData();
      return forbiddenData;
    }

    public override async Task RunAsync(AbstractTelegramBot bot, Update update, CancellationToken cancellationToken)
    {
      if (update.Message is { From: not null }) await AdminUtils.CheckIfUserIsAdmin(RoleData, update.Message.From, update.Message.Chat.Id, bot);
      // check if message is user is admin or global admin
      // check if message is spam
      // if message is spam, delete it
    }
  }
}