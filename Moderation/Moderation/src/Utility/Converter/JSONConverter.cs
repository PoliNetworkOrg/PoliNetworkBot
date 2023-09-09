using Newtonsoft.Json;

namespace Moderation.Utility.Converter;

class JSONConverter
{
  public static string[]? GetArrayFromString(string json)
  {
    return JsonConvert.DeserializeObject<string[]>(json)?.ToArray();
  }

  public static string[]? GetArrayFromFile(string path)
  {
    string json = File.ReadAllText(path);
    return GetArrayFromString(json);
  }
}