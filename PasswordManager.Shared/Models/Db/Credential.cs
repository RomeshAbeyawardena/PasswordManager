﻿using DNI.Shared.Attributes;
using PasswordManager.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Models.Db
{
    public class Credential
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int CredentialTypeId { get; set; }
        public string Value { get; set; }

        public Guid AccountId { get; set; }

        [MetaProperty(DNI.Shared.Enumerations.MetaAction.Add)]
        public DateTimeOffset Created { get; set; }

        [MetaProperty(DNI.Shared.Enumerations.MetaAction.Update)]
        public DateTimeOffset? Modified { get; set; }

        [NotMapped]
        public CredentialType? Type => (CredentialType)CredentialTypeId;
    }
}
