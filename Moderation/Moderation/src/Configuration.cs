namespace Moderation
{
    public static class Config
    {
        private static readonly string? BASE_PATH = Directory.GetParent(Environment.CurrentDirectory)?.FullName;
        public static readonly string FORBIDDEN_WORDS = BASE_PATH + @"\Moderation\src\persistence\forbidden.json";
        public static readonly string APP_SETTINGS = BASE_PATH + @"\Moderation\src\persistence\appsettings.json";
        public static readonly string ROLES_DATA = BASE_PATH + @"\Moderation\src\persistence\roles.json";
    }
}