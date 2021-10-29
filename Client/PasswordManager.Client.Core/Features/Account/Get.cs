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
                Id = NewGuid,
                Tiles = GetTiles(),
                UserName = "romesh.a"
            }));
        }

        private Guid NewGuid => Guid.NewGuid();

        private IEnumerable<SimpleTile> GetTiles()
        {
            return new[]
            {
                new SimpleTile { 
                    Id = NewGuid,
                    Name = "Romesh E-mail",
                    Description = "romesh.abeyawardena@dotnetinsights.net",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0)
                },
                new SimpleTile {
                    Id = NewGuid,
                    Name = "Krish E-mail",
                    Description = "krish.ellis@dotnetinsights.net",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0)
                },
                new SimpleTile {
                    Id = NewGuid,
                    Name = "Halifax Bank",
                    Description = "Internet banking",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0)
                },
                new SimpleTile {
                    Id = NewGuid,
                    Name = "RBS Bank",
                    Description = "Internet banking",
                    LastUpdated = new DateTime(2021, 02, 01, 15, 30, 0)
                }
            };
        }
    }
}
