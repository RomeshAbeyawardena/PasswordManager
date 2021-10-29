using AutoMapper;
using PasswordManager.Shared.Queries.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Client.Core.Features.Account
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<AccountViewModel, GetAccountQuery>();
        }
    }
}
