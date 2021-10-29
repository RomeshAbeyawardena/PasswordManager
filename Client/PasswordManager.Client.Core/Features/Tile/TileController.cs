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
    public class TileController : ApiControllerBase
    {
        public Task<IActionResult> GetTile([FromQuery] string payload, CancellationToken cancellationToken)
        {
            var tileViewModel = TileViewModel.FromPayload(payload, Encoding.UTF8);

            var query = this.Map<GetTileQuery>(tileViewModel);
            return this.Process(this.Send(query, cancellationToken));
        }
    }
}
