using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Client.Core.Features.Account
{
    public class AccountViewModel
    {
        public static AccountViewModel FromPayload(string payload, Encoding encoding)
        {
            return new AccountViewModel(payload, encoding);
        }

        private AccountViewModel(string payload, Encoding encoding)
        {
            payload = encoding.GetString(Convert.FromBase64String(payload));

            if (Guid.TryParse(payload, out var accountId))
            {
                AccountId = accountId;
            }
        }

        public Guid AccountId { get; set; }
    }
}
