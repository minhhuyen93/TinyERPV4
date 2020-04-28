namespace TinyERP.Common.Helpers
{
    using System.IO;
    using TinyERP.Common.Config;
    using TinyERP.Common.Enums;

    internal class DataBaseConnectionHelper
    {
        public static string GetConnectionString(string moduleConnectionConfiguration)
        {
            var settingPath = Path.GetFullPath(Path.Combine(@"./Config/SharedSettings.json"));
            string sharedSetting = System.IO.File.ReadAllText(settingPath);
            SystemConfiguration systemConfigurationObject = Newtonsoft.Json.JsonConvert.DeserializeObject<SystemConfiguration>(sharedSetting);
            return DataBaseConnectionHelper.GetConnectionStringByKey(moduleConnectionConfiguration, systemConfigurationObject);
        }
        private static string GetConnectionStringByKey(string moduleKey, SystemConfiguration systemConfiguration)
        {
            switch (moduleKey)
            {
                case ModuleConfiguration.InventoryModule:
                    return systemConfiguration.DataBaseConnections.InventoryModule.ConnectionString;
                case ModuleConfiguration.SecurityModule:
                    return systemConfiguration.DataBaseConnections.SecurityModule.ConnectionString;
                default:
                    return null;
            }
        }
    }
}
