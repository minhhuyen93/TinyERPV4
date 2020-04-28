namespace TinyERP.Common.Application
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using System.IO;
    using TinyERP.Common.Helpers;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using System.Collections.Generic;

    public class CommonStartup
    {
        public IConfiguration Configuration { get; private set; }
        public CommonStartup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var settingPath = Path.GetFullPath(Path.Combine(@"./appsettings.json"));
            var appSettingConfiguration = FileHelper.GetAppSettingsConfiguration(settingPath);
            var key = Encoding.ASCII.GetBytes(appSettingConfiguration.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudiences = new List<string>
                    {
                        appSettingConfiguration.Authentication.AppIdUri
                    }
                };
            });
            services.AddCors(confg =>
                confg.AddPolicy("AllowAll",
                    p => p.AllowAnyOrigin().WithOrigins("http://testlocalhost")
                        .AllowAnyMethod()
                        .AllowAnyHeader()));
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
