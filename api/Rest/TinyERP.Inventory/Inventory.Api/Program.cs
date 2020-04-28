using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TinyERP.Common.Config;

namespace Inventory.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((hostContext, options) =>
                {
                    BaseConfigurationProgram.BuildCommonConfiguration(hostContext, options);
                });
    }
}
