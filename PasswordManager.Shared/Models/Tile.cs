using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Models
{
    public class Tile
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdated { get; set; }
        public IEnumerable<AccountCredential> Credentials { get; set; }
    }
}
