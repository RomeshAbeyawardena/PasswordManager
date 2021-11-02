using DNI.Mapper.Extensions;
using DNI.Mediator.Extensions;
using DNI.Web.Shared.Base;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Shared.Queries.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Client.Core.Features.Tile
{
    public class TileController : ClientApiControllerBase
    {
        public Task<IActionResult> GetTile([FromQuery] string payload, CancellationToken cancellationToken)
        {
            var query = GetTileQuery.FromPayload(payload, Encoding.UTF8);

            return this.Process(this.Send(query, cancellationToken));
        }
    }
}
