using DNI.Mediator.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Queries.Tiles
{
    public class GetTileQuery : IRequest<Models.Tile>
    {
        public Guid AccountId { get; set; }
        public Guid TileId { get; set; }
    }
}
