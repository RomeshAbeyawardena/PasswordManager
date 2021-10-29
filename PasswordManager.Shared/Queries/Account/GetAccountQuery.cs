using DNI.Mediator.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Queries.Account
{
    public class GetAccountQuery : IRequest<Models.Account>
    {
        public Guid AccountId { get; set; }
    }
}
