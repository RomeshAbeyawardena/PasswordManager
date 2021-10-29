using DNI.Modules.Shared.Abstractions.Builders;
using DNI.Modules.Shared.Base;
using Microsoft.Extensions.DependencyInjection;
using DNI.Modules.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Client;
using PasswordManager.Server;

namespace PasswordManager.App.Modules
{
    public class AppModule : ModuleBase
    {
        public override void ConfigureModuleBuilder(IServiceCollection services, IModuleConfigurationBuilder moduleConfigurationBuilder)
        {
            moduleConfigurationBuilder
                .AddModule<ClientModule>()
                .AddModule<ServerModule>();
        }
    }
}
