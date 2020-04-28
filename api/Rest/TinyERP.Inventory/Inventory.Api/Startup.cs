namespace Inventory.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using TinyERP.Common.Application;
    using TinyERP.Common.Enums;
    public class Startup : CommonStartup
    {
        private IApplication app;
        public Startup(IConfiguration configuration):base(configuration)
        {
            this.app = ApplicationFactory.Create(ApplicationType.WebApi);
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Inventory Api Swagger", Version = "1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            base.Configure(app, env, applicationLifetime);
            applicationLifetime.ApplicationStarted.Register(OnApplicationStarted);
            applicationLifetime.ApplicationStopped.Register(OnApplicationEnded);
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory V1");
                c.RoutePrefix = string.Empty;
            });
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
