
using DNI.Mediator.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Queries.User
{
    public class SaveRequest : IRequest<Models.Db.User>
    {
        public Guid? Id { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
        
        public string Password { get; set; }

        public bool Commit { get; set; }

        public Models.Db.Customer Customer { get; set; }
    }
}
