namespace TinyERP.Common.Helpers
{
    using TinyERP.Common.Config;
    public static class FileHelper
    {
        public static AppSettingConfiguration GetAppSettingsConfiguration(string filePath)
        {
            string appSettings = System.IO.File.ReadAllText(filePath);
            AppSettingConfiguration appSettingConfiguration = Newtonsoft.Json.JsonConvert.DeserializeObject<AppSettingConfiguration>(appSettings);
            return appSettingConfiguration;
        }
    }
}
