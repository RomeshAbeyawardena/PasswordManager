using AutoMapper;
using Queries = PasswordManager.Shared.Queries;
using Models = PasswordManager.Shared.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Server.Core.Features.User
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Queries.User.RegisterRequest, Queries.User.SaveRequest>();
            CreateMap<Queries.User.SaveRequest, Models.User>()
                .ForMember(member => member.PasswordHash, 
                    configuration => configuration
                        .MapFrom(member => member.Password));
        }
    }
}
