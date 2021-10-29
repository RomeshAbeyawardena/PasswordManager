using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Client.Core.Features.Tile
{
    public class TileViewModel
    {
        public static TileViewModel FromPayload(string payload, Encoding encoding)
        {
            return new TileViewModel(payload, encoding);
        }

        private TileViewModel(string payload, Encoding encoding)
        {
            payload = encoding.GetString(Convert.FromBase64String(payload));

            var payloadItems = payload.Split("|", StringSplitOptions.RemoveEmptyEntries);



            if (Guid.TryParse(encoding.GetString(Convert.FromBase64String(payloadItems[0])), out var accountId))
            {
                AccountId = accountId;
            }

            if (Guid.TryParse(encoding.GetString(Convert.FromBase64String(payloadItems[1])), out var tileId))
            {
                TileId = tileId;
            }
        }

        public Guid AccountId { get; set; }
        public Guid TileId { get; set; }
    }
}
