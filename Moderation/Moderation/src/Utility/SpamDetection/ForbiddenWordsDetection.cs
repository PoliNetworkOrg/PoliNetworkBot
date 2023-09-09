using System.Text.RegularExpressions;
using Moderation.Bot;
using Moderation.Utility.Converter;
using Newtonsoft.Json;
using PoliNetwork.Core.Utils.LoggerNS;
using PoliNetwork.Telegram.Utility.Logger;
using Telegram.Bot;

namespace Moderation.Utility.SpamDetection;

public class ForbiddenData
{
    public ForbiddenData(List<string>? forbiddenWords = null, List<string>? forbiddenDomains = null)
    {
        ForbiddenWords = forbiddenWords ?? new List<string>();
        ForbiddenDomains = forbiddenDomains ?? new List<string>();
    }

    public List<string> ForbiddenWords { get; set; }
    public List<string> ForbiddenDomains { get; set; }
}

public class ForbiddenWordsDetection
{
    public static ForbiddenData ForbiddenData { get; set; } = LoadForbiddenData();

    private static ForbiddenData LoadForbiddenData()
    {
        var path = Config.FORBIDDEN_WORDS;
        ForbiddenData? forbiddenDataRaw = null;
        try
        {
            forbiddenDataRaw = JsonConvert.DeserializeObject<ForbiddenData>(File.ReadAllText(path));
        }
        catch (Exception e)
        {
            var logger = new DefaultLogger();
            logger.Error("Got an exception while trying to deserialize object in ForbiddenWordsDetection");
            logger.Error(e);
        }
        var forbiddenData = forbiddenDataRaw ?? new ForbiddenData();
        return forbiddenData;
    }

    public static Task<bool> IsForbiddenWordAsync(string message)
    {
        var forbiddenWords = ForbiddenData.ForbiddenWords;
        foreach (var pattern in forbiddenWords)
        {
            try
            {
                //BACKTRACKING is disabled for DDOS protection, use less complex regex!
                if (Regex.IsMatch(message.ToLower(), pattern, RegexOptions.NonBacktracking))
                    return Task.FromResult(true);
            }
            catch (ArgumentException e)
            {
                var logger = new DefaultLogger();
                logger.Error($"The given pattern {pattern} is not valid", e);
            }
        }
        return Task.FromResult(false);
    }

    public static Task<bool> IsForbiddenLink(string message)
    {
        var forbiddenDomains = ForbiddenData.ForbiddenDomains;
        return Task.FromResult(forbiddenDomains.Any(message.Contains));
    }
}