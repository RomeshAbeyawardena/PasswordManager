using DNI.Mediator.Extensions;
using DNI.Web.Shared.Base;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Shared.Queries.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Server.Core.Features.User
{
    public class UserController : ApiControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetUser([FromQuery] GetQuery query, CancellationToken cancellationToken)
        {
            return this.Process(this.Send(query, cancellationToken));
        }

        [HttpPost]
        public Task<IActionResult> RegisterUser([FromForm] RegisterRequest request, CancellationToken cancellationToken)
        {
            return this.Process(this.Send(request, cancellationToken));
        }
    }
}
