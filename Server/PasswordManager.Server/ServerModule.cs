using DNI.Mapper.Modules.Extensions;
using DNI.Mediator.Modules.Extensions;
using DNI.Modules.Shared.Abstractions.Builders;
using DNI.Modules.Shared.Base;
using DNI.Web.Modules.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DNI.Modules.Extensions;
using DNI.Encryption.Modules.Extensions;

namespace PasswordManager.Server
{
    public class ServerModule : ModuleBase
    {
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
                    .ConfigureWebHost(ConfigureWebHost));
        }

        private void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.PreferHostingUrls(true)
                .UseUrls("http://localhost:5600");
        }
    }
}
