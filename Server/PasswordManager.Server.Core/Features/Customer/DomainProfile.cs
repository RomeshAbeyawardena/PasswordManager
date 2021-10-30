using AutoMapper;
using Queries = PasswordManager.Shared.Queries;
using Models = PasswordManager.Shared.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Server.Core.Features.Customer
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Queries.User.RegisterRequest, Queries.Customer.SaveRequest>();
            CreateMap<Queries.Customer.SaveRequest, Models.Customer>();
        }
    }
}
