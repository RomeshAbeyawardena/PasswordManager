using DNI.Mediator.Shared.Abstractions;
using DNI.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Queries.Tiles
{
    public class GetTileQuery : IRequest<Models.Tile>
    {
        public static GetTileQuery FromPayload(string value, Encoding encoding = default)
        {
            GetTileQuery query = new();
            var payload = value.ExtractPayload(encoding: encoding);

            if(Guid.TryParse(payload[0], out var accountId))
            {
                query.AccountId = accountId;
            }

            if (Guid.TryParse(payload[1], out var tileId))
            {
                query.TileId = tileId;
            }

            return query;
        }

        public Guid AccountId { get; set; }
        public Guid TileId { get; set; }
    }
}
