using AutoMapper;
using DNI.Extensions;
using DNI.Mediator.Extensions;
using DNI.Mediator.Shared.Abstractions;
using DNI.Mediator.Shared.Base;
using DNI.Shared.Abstractions.Collections;
using MediatR;
using PasswordManager.Shared.Queries.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PasswordManager.Shared.Models.Db;
using DNI.Encryption.Shared.Abstractions;

namespace PasswordManager.Client.Core.Features.Account
{
    public class Authenticate : IRequestResponseHandler<AuthenticateUserRequest, Guid>
    {
        private readonly IMapper mapper;
        private readonly IModelEncryptor modelEncryptor;
        private readonly IMediator mediator;

        public Authenticate(
            IMapper mapper,
            IModelEncryptor modelEncryptor,
            IMediator mediator)
        {
            this.mapper = mapper;
            this.modelEncryptor = modelEncryptor;
            this.mediator = mediator;
        }

        public Task<IResponse<Guid>> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
        {
            var userRequest = mapper.Map<GetQuery>(request);
            var user = mapper.Map<User>(request);
            var encryptedUser = modelEncryptor.Encrypt(user);
            async Task<Guid> HandleResponse(IValidationFailureCollection validationFailures)
            {
                var response = await mediator.Send(mapper.Map<GetQuery>(request));

                if (!response.Succeeded)
                {
                    validationFailures.Add(request, "Invalid e-mail address or password", "EmailAddress");
                    return Guid.Empty;
                }

                if (response.Result.PasswordHash != encryptedUser.PasswordHash)
                {
                    validationFailures.Add(request, "Invalid e-mail address or password", "Password");
                    return Guid.Empty;
                }

                return response.Result.Id;
            }

            return this.Response(u => u != Guid.Empty, HandleResponse);
            
        }
    }
}
