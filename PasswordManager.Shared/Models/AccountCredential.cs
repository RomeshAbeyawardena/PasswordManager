using PasswordManager.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Models
{
    public class AccountCredential
    {
        public Guid Id { get; set; }
        public CredentialType Type { get; set; }
        public IEnumerable<string> Value { get; set; }
    }
}
