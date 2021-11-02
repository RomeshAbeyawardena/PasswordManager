using DNI.Mapper.Modules.Extensions;
using DNI.Mediator.Modules.Extensions;
using DNI.Modules.Shared.Abstractions.Builders;
using DNI.Modules.Shared.Base;
using DNI.Web.Modules.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DNI.Modules.Extensions;
using DNI.Encryption.Modules.Extensions;
using DNI.Hangfire.Modules.Extensions;
using Hangfire;
using System;
using System.Net;
using Microsoft.Extensions.Configuration;
using Hangfire.SqlServer;

namespace PasswordManager.Server
{
    public class ServerModule : ModuleBase
    {
        private readonly IConfiguration configuration;

        public ServerModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public override void ConfigureModuleBuilder(IServiceCollection services, IModuleConfigurationBuilder moduleConfigurationBuilder)
        {
            moduleConfigurationBuilder
                .AddModule<DbModule>()
                .ConfigureEncryptionModule(builder => builder.ImportConfiguration("SecurityProfiles/General"))
                .ConfigureMapperModule(builder => builder
                    .AddAssembly(Core.This.Assembly))
                .ConfigureMediatorModule(builder => builder
                    .AddAssembly(Core.This.Assembly))
                .ConfigureWebModule<ServerModule>(builder => builder
                    .AddAssembly(Core.This.Assembly)
                    .ConfigureWebHost(ConfigureWebHost))
                .ConfigureHangfireModule<ServerModule>(builder => builder
                    .UseHangfireDashboard()
                    .ConfigureOptions("/hangfire", new DashboardOptions { }, null)
                    .ConfigureHangfire(ConfigureHangfire)
                    .ConfigureWebHost(ConfigureHangfireHost));
        }

        private void ConfigureHangfireHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.ConfigureKestrel(a => a.Listen(IPAddress.Any, 5200));
        }

        private void ConfigureHangfire(IGlobalConfiguration configuration)
        {
            configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(this.configuration.GetConnectionString("hangfire"), new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true
            });
        }

        private void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.PreferHostingUrls(true)
                .UseUrls("http://localhost:5600");
        }
    }
}
