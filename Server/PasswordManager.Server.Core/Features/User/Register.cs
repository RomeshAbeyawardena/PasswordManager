using AutoMapper;
using DNI.Encryption.Shared.Abstractions;
using DNI.Mediator.Shared.Abstractions;
using DNI.Mediator.Shared.Base;
using DNI.Shared.Abstractions;
using DNI.Shared.Exceptions;
using MediatR;
using PasswordManager.Shared.Queries.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Models = PasswordManager.Shared.Models.Db;

namespace PasswordManager.Server.Core.Features.User
{
    public class Register : IRequestResponseHandler<RegisterRequest, Guid>
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly IAsyncRepository<Models.User> userRepository;

        public Register(
            IMapper mapper,
            IMediator mediator,
            IAsyncRepository<Models.User> userRepository)
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.userRepository = userRepository;
        }

        public async Task<IResponse<Guid>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var customerSaveRequest = mapper.Map<Shared.Queries.Customer.SaveRequest>(request);
            var userSaveRequest = mapper.Map<SaveRequest>(request);
            var response = await mediator.Send(customerSaveRequest, cancellationToken);

            if (!response.Succeeded)
            {
                throw new ModelStateException(request, response.ValidationFailures);
            }

            userSaveRequest.Customer = response.Result;

            var userResponse = await mediator.Send(userSaveRequest, cancellationToken);

            if (!userResponse.Succeeded)
            {
                throw new ModelStateException(request, response.ValidationFailures);
            }

            await userRepository.SaveChangesAsync(cancellationToken);

            return Response.Success(userResponse.Result.Id);
        }
    }
}
