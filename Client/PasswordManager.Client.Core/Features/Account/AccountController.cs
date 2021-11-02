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
using PasswordManager.Shared.Queries.User;

namespace PasswordManager.Client.Core.Features.Account
{
    public class AccountController : ClientApiControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetAccount([FromQuery] string payload, CancellationToken cancellationToken)
        {
            var query = GetAccountQuery.FromPayload(payload, Encoding.UTF8);

            return this.Process(this.Send(query, cancellationToken));
        }

        [HttpPost, Route("authenticate")]
        public Task<IActionResult> Authenticate([FromForm] string payload, CancellationToken cancellationToken)
        {
            var query = AuthenticateUserRequest.FromPayload(payload);

            return this.Process(this.Send(query, cancellationToken));
        }
    }
}
