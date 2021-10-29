using DNI.Mediator.Shared.Abstractions;
using MediatR;
using PasswordManager.Shared.Queries.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Client.Core.Features.Tile
{
    public class Get : IRequestHandler<GetTileQuery, IResponse<Shared.Models.Tile>>
    {
        public Task<IResponse<Shared.Models.Tile>> Handle(GetTileQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
