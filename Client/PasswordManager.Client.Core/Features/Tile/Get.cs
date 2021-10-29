using DNI.Mediator.Shared.Abstractions;
using DNI.Mediator.Shared.Base;
using MediatR;
using PasswordManager.Shared.Models;
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
        private IEnumerable<AccountCredential> AccountCredentials => new []{
            new AccountCredential
            {
                Id = Guid.NewGuid(),
                Description = "Password",
                Type = Shared.Enumerations.CredentialType.Password,
                Value = "Password12345".ToCharArray()
            },
            new AccountCredential
            {
                Id = Guid.NewGuid(),
                Description = "Passphrase",
                Type = Shared.Enumerations.CredentialType.MemorialWord,
                Value = "Password12345".ToCharArray()
            },
            new AccountCredential
            {
                Id = Guid.NewGuid(),
                Description = "PIN Code",
                Type = Shared.Enumerations.CredentialType.PinCode,
                Value = "6958439".ToCharArray()
            }
        };


        private IEnumerable<Shared.Models.Tile> GetData()
        {
            return new[] {  new Shared.Models.Tile {
                    Id = new Guid("e7015b40c2c04242a511cd0e0c799940"),
                    Name = "Romesh E-mail",
                    Description = "romesh.abeyawardena@dotnetinsights.net",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0),
                    Credentials = AccountCredentials
                },
                new Shared.Models.Tile {
                    Id = new Guid("c4e9e064a6434f35a048b35bb2be826f"),
                    Name = "Krish E-mail",
                    Description = "krish.ellis@dotnetinsights.net",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0),
                    Credentials = Array.Empty<AccountCredential>()
                },
                new Shared.Models.Tile {
                    Id = new Guid("ddd122c6379840da848e75231f440712"),
                    Name = "Halifax Bank",
                    Description = "Internet banking",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0),
                    Credentials = Array.Empty<AccountCredential>()
                },
                new Shared.Models.Tile {
                    Id = new Guid("8ef0bad7b4ad48ad96df05f0d60f2ff7"),
                    Name = "RBS Bank",
                    Description = "Internet banking",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0),
                    Credentials = Array.Empty<AccountCredential>()
                } 
            };
        }

        public Task<IResponse<Shared.Models.Tile>> Handle(GetTileQuery request, CancellationToken cancellationToken)
        {
            var data = GetData();

            return Task.FromResult(Response.Success(data.FirstOrDefault(a => a.Id == request.TileId)));
        }
    }
}
