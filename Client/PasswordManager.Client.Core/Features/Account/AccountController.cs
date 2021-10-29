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

namespace PasswordManager.Client.Core.Features.Account
{
    public class AccountController : ApiControllerBase
    {
        public Task<IActionResult> GetAccount([FromQuery] GetAccountQuery query, CancellationToken cancellationToken)
        {
            return this.Process(this.Send(query, cancellationToken));
        }
    }
}
