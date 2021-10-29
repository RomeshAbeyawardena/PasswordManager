using DNI.Mapper.Modules.Extensions;
using DNI.Mediator.Modules.Extensions;
using DNI.Modules.Shared.Abstractions.Builders;
using DNI.Modules.Shared.Base;
using DNI.Web.Modules.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Client.Core.Features.Account;
using System;

namespace PasswordManager.Client
{
    public class ClientModule : ModuleBase
    {
        public override void ConfigureModuleBuilder(IServiceCollection services, IModuleConfigurationBuilder moduleConfigurationBuilder)
        {
            moduleConfigurationBuilder
                .ConfigureMapperModule(builder => builder
                    .AddAssembly(Core.This.Assembly))
                .ConfigureMediatorModule(builder => builder
                    .AddAssembly(Core.This.Assembly))
                .ConfigureWebModule<ClientModule>(builder => builder
                    .AddAssembly(Core.This.Assembly)
                    .ConfigureServices(ConfigureServices)
                    .ConfigureApplicationBuilder(configureApplicationBuilder)
                    .ConfigureWebHost(ConfigureWebHost));
        }

        private void configureApplicationBuilder(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseCors();
        }

        private void ConfigurePolicy(CorsPolicyBuilder corsPolicyBuilder)
        {
            corsPolicyBuilder
                .WithOrigins("http://localhost")
                .WithMethods("GET", "POST")
                .AllowAnyHeader();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(Configure);
        }

        private void Configure(CorsOptions options)
        {
            options.AddDefaultPolicy(ConfigurePolicy);
        }

        private void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder
                .PreferHostingUrls(true)
                .UseUrls("http://localhost:5500");
        }
    }
}
