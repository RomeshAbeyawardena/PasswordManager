using DNI.Mapper.Modules.Extensions;
using DNI.Mediator.Modules.Extensions;
using DNI.Modules.Shared.Abstractions.Builders;
using DNI.Modules.Shared.Base;
using DNI.Web.Modules.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DNI.Modules.Extensions;
using PasswordManager.Server.Core.Features.Account;
using System;

namespace PasswordManager.Server
{
    public class ServerModule : ModuleBase
    {
        public override void ConfigureModuleBuilder(IServiceCollection services, IModuleConfigurationBuilder moduleConfigurationBuilder)
        {
            moduleConfigurationBuilder
                .AddModule<DbModule>()
                .ConfigureMapperModule(builder => builder
                    .AddAssembly<AccountController>())
                .ConfigureMediatorModule(builder => builder
                    .AddAssembly<AccountController>())
                .ConfigureWebModule<ServerModule>(builder => builder
                    .AddAssembly<AccountController>()
                    .ConfigureWebHost(ConfigureWebHost));
        }

        private void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.PreferHostingUrls(true)
                .UseUrls("http://localhost:5600");
        }
    }
}
