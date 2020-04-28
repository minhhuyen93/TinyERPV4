using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TinyERP.Common.Application;
using TinyERP.Common.Enums;

namespace Application
{
    public class Startup : CommonStartup
    {
        private IApplication app;
        public Startup(IConfiguration configuration):base(configuration)
        {
            this.app = ApplicationFactory.Create(ApplicationType.WebApi);
        }

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            base.Configure(app, env, applicationLifetime);
            applicationLifetime.ApplicationStarted.Register(OnApplicationStarted);
            applicationLifetime.ApplicationStopped.Register(OnApplicationEnded);
        }
        private void OnApplicationStarted()
        {
            this.app.OnApplicationStarted();
        }
        private void OnApplicationEnded()
        {
            this.app.OnApplicationEnded();
        }
    }
}
