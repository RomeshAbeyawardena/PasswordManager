using DNI.Mediator.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Queries.User
{
    public class GetUserQuery : IRequest<Models.Db.User>
    {
        public Guid? Id { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
    }
}
