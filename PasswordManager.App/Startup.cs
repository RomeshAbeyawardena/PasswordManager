using DNI.Modules.Shared.Abstractions;
using DNI.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.App
{
    public class Startup : DisposableStartupBase
    {
        private readonly IModuleStartup moduleStartup;

        public Startup(IModuleStartup moduleStartup)
        {
            this.moduleStartup = moduleStartup;
        }

        public override void Dispose(bool disposing)
        {
            moduleStartup.Dispose();
        }

        public override Task StartAsync(CancellationToken cancellationToken, params object[] args)
        {
            return moduleStartup.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return moduleStartup.StopAsync(cancellationToken);
        }
    }
}
