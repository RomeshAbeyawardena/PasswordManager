using DNI.Mediator.Shared.Abstractions;
using MediatR;
using PasswordManager.Shared.Queries.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Client.Core.Features.Account
{
    public class Get : IRequestHandler<GetAccountQuery, IResponse<Shared.Models.Account>>
    {
        public Task<IResponse<Shared.Models.Account>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
