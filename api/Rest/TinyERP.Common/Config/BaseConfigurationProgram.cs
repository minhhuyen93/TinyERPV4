namespace TinyERP.Common.Config
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    public class BaseConfigurationProgram
    {
        public static void BuildCommonConfiguration(HostBuilderContext hostContext, IConfigurationBuilder options){
            options.Sources.Clear();
            options.AddJsonFile("./Config/SharedSettings.json");
        }
    }
}
