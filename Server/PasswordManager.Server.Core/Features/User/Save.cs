using AutoMapper;
using DNI.Encryption.Shared.Abstractions;
using DNI.Extensions;
using DNI.Mediator.Extensions;
using DNI.Mediator.Shared.Abstractions;
using DNI.Mediator.Shared.Base;
using DNI.Shared.Abstractions;
using DNI.Shared.Abstractions.Collections;
using Microsoft.EntityFrameworkCore;
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
    public class Save : IRequestResponseHandler<SaveRequest, Models.User>
    {
        private readonly IDictionary<string, IEncryptionOptions> encryptionOptions;
        private readonly IAsyncRepository<Models.User> userRepository;
        private readonly IModelEncryptor modelEncryptor;
        private readonly IMapper mapper;

        public Save(
           IDictionary<string, IEncryptionOptions> encryptionOptions,
           IAsyncRepository<Models.User> userRepository,
           IModelEncryptor modelEncryptor,
           IMapper mapper)
        {
            this.encryptionOptions = encryptionOptions;
            this.userRepository = userRepository;
            this.modelEncryptor = modelEncryptor;
            this.mapper = mapper;
        }

        public async Task<IResponse<Models.User>> Handle(SaveRequest request, CancellationToken cancellationToken)
        {
            var query = userRepository.Query.IgnoreAutoIncludes();

            var newUser = mapper.Map<Models.User>(request);
            var encryptedUser = modelEncryptor.Encrypt(newUser);

            async Task<Models.User> ResponseHandler(IValidationFailureCollection validationFailures)
            {
                if (query.Any(a => a.EmailAddress == encryptedUser.EmailAddress))
                {
                    validationFailures.Add(encryptedUser, "User with requested email address already exists", "EmailAddress");
                    return null;
                }

                userRepository.Add(encryptedUser);

                if (request.Commit)
                {
                    await userRepository.SaveChangesAsync(cancellationToken);
                }

                return encryptedUser;
            }


            return await this.Response(u => u != null, ResponseHandler);
            
        }
    }
}
