using DNI.Mediator.Shared.Abstractions;
using DNI.Shared.Extensions;
using PasswordManager.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Queries.User
{
    public class AuthenticateUserRequest : IRequest<Guid>
    {
        public static AuthenticateUserRequest FromPayload(string payload)
        {
            var requests = payload.ExtractPayload();

            AuthenticateUserRequest query = new();
            query.EmailAddress = requests[0];
            query.Password = requests[1];

            return query;
        }

        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
