using DNI.Web.Shared.Base;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Shared.Queries.Account;
using DNI.Mediator.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DNI.Mapper.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace PasswordManager.Client.Core.Features.Account
{
    public class AccountController : ClientApiControllerBase
    {
        public Task<IActionResult> GetAccount([FromQuery] string payload, CancellationToken cancellationToken)
        {
            var accountViewModel = AccountViewModel.FromPayload(payload, Encoding.UTF8);

            var query = this.Map<GetAccountQuery>(accountViewModel);

            return this.Process(this.Send(query, cancellationToken));
        }

        public Task<IActionResult> Authenticate([FromQuery] string payload, CancellationToken cancellationToken)
        {

        }
    }
}
