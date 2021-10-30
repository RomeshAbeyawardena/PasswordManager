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
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        [EncryptionProfile(Constants.EncryptionProfiles.Common)]
        public string FirstName { get; set; }

        [EncryptionProfile(Constants.EncryptionProfiles.Common)]
        public string MiddleName { get; set; }

        [EncryptionProfile(Constants.EncryptionProfiles.Common)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MetaProperty(DNI.Shared.Enumerations.MetaAction.Add)]
        public DateTimeOffset Created { get; set; }

        [MetaProperty(DNI.Shared.Enumerations.MetaAction.Update)]
        public DateTimeOffset? Modified { get; set; }

    }
}
