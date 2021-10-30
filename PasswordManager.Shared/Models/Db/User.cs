using DNI.Encryption.Shared.Attributes;
using DNI.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Models.Db
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [EncryptionProfile(Constants.EncryptionProfiles.Personal)]
        public string UserName { get; set; }
        [EncryptionProfile(Constants.EncryptionProfiles.Personal)]
        public string EmailAddress { get; set; }
        [EncryptionProfile(Constants.EncryptionProfiles.Personal, DNI.Encryption.Shared.Enumerations.EncryptionType.Hash)]
        public string PasswordHash { get; set; }
        
        public int CustomerId { get; set; }

        [MetaProperty(DNI.Shared.Enumerations.MetaAction.Add)]
        public DateTimeOffset Created { get; set; }

        [MetaProperty(DNI.Shared.Enumerations.MetaAction.Update)]
        public DateTimeOffset? Modified { get; set; }
        
        public ICollection<Account> Accounts { get; set; }
        public Customer Customer { get; set; }
    }
}
