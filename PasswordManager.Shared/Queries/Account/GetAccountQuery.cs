using DNI.Mediator.Shared.Abstractions;
using DNI.Shared.Extensions;
using PasswordManager.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Queries.Account
{
    public class GetAccountQuery : IRequest<Models.Account>
    {
        public static GetAccountQuery FromPayload(string value, Encoding encoding = default)
        {
            var payload = value.ExtractPayload(encoding: encoding);
            
            GetAccountQuery query = new();
            
            if (Guid.TryParse(payload[0], out var accountId))
            {
                query.AccountId = accountId;
            }

            return query;
        }

        public Guid AccountId { get; set; }
    }
}
