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
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        
        [EncryptionProfile(Constants.EncryptionProfiles.Personal)]
        public string Name { get; set; }
        
        [EncryptionProfile(Constants.EncryptionProfiles.Personal)]
        public string Description { get; set; }

        [MetaProperty(DNI.Shared.Enumerations.MetaAction.Add | DNI.Shared.Enumerations.MetaAction.Update)]
        public DateTime? LastUpdated { get; set; }
        
        public Guid UserId { get; set; }

        [MetaProperty(DNI.Shared.Enumerations.MetaAction.Add)]
        public DateTimeOffset Created { get; set; }

        [MetaProperty(DNI.Shared.Enumerations.MetaAction.Update)]
        public DateTimeOffset? Modified { get; set; }

        public ICollection<Credential> Credentials { get; set; }
    }
}
