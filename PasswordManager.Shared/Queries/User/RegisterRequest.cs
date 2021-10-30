using DNI.Mediator.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Queries.User
{
    public class RegisterRequest : IRequest<Guid>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
