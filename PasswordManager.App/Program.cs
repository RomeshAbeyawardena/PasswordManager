using DNI.Core.Defaults.Hosts;
using DNI.Extensions;
using DNI.Modules.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PasswordManager.App.Modules;
using System;
using System.Threading.Tasks;

namespace PasswordManager.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using var consoleHost = ConsoleHost
                .Build(build => build
                .ConfigureServices<Startup>(ConfigureServices)
                .AddDefaultConfiguration());

            await consoleHost.StartAsync(args: args);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddLogging(c => c.AddConsole())
                .AddModules(builder => builder
                    .AddModule<AppModule>());
        }
    }
}
