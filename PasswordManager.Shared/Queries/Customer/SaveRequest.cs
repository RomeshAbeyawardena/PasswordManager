using DNI.Mediator.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Queries.Customer
{
    public class SaveRequest : IRequest<Models.Db.Customer>
    {
        public Guid? Id { get; set; }
        
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Commit { get; set; }
    }
}
