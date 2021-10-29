using DNI.Mediator.Shared.Abstractions;
using DNI.Mediator.Shared.Base;
using MediatR;
using PasswordManager.Shared.Models;
using PasswordManager.Shared.Queries.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Client.Core.Features.Account
{
    public class Get : IRequestHandler<GetAccountQuery, IResponse<Shared.Models.Account>>
    {
        public Task<IResponse<Shared.Models.Account>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Response.Success(new Shared.Models.Account { 
                EmailAddress = "romesh.abeyawardena@dotnetinsights.net",
                Id = new Guid("6c3a79b09e41413eb0c50ff82cafbe68"),
                Tiles = GetTiles(),
                UserName = "romesh.a"
            }));
        }


        private IEnumerable<SimpleTile> GetTiles()
        {
            return new[]
            {
                new SimpleTile {
                    Id = new Guid("e7015b40c2c04242a511cd0e0c799940"),
                    Name = "Romesh E-mail",
                    Description = "romesh.abeyawardena@dotnetinsights.net",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0)
                },
                new SimpleTile {
                    Id = new Guid("c4e9e064a6434f35a048b35bb2be826f"),
                    Name = "Krish E-mail",
                    Description = "krish.ellis@dotnetinsights.net",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0)
                },
                new SimpleTile {
                    Id = new Guid("ddd122c6379840da848e75231f440712"),
                    Name = "Halifax Bank",
                    Description = "Internet banking",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0)
                },
                new SimpleTile {
                    Id = new Guid("8ef0bad7b4ad48ad96df05f0d60f2ff7"),
                    Name = "RBS Bank",
                    Description = "Internet banking",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0)
                }
            };
        }
    }
}
