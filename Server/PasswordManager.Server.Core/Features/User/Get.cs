using DNI.Core.Defaults;
using DNI.Encryption.Shared.Abstractions;
using DNI.Extensions;
using DNI.Mediator.Extensions;
using DNI.Mediator.Shared.Abstractions;
using DNI.Mediator.Shared.Base;
using DNI.Mediator.Shared.Defaults;
using DNI.Shared.Abstractions;
using DNI.Shared.Abstractions.Collections;
using DNI.Shared.Defaults.Collections;
using DNI.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using Models = PasswordManager.Shared.Models.Db;
using PasswordManager.Shared.Queries.User;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Server.Core.Features.User
{
    public class Get : IRequestResponseHandler<GetQuery, Models.User>
    {
        private readonly IModelEncryptor modelEncryptor;
        private readonly IAsyncRepository<Models.User> userRepository;

        public Get(IModelEncryptor modelEncryptor, 
            IAsyncRepository<Models.User> userRepository)
        {
            this.modelEncryptor = modelEncryptor;
            this.userRepository = userRepository;
        }

        public Task<IResponse<Models.User>> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var query = userRepository.Query
                   .Include(user => user.Accounts)
                   .ThenInclude(account => account.Credentials);

            var encryptedRequest = modelEncryptor.Encrypt(request);


            async Task<Models.User> ResponseHandler(IValidationFailureCollection validationFailures)
            {
                Models.User user = new();

                if (request.Id.HasValue)
                {
                    user = await query.FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken);
                }
                else
                    validationFailures.Add(user, new NullReferenceException("User Id not specified"), "Id");

                if (!string.IsNullOrEmpty(request.Username))
                {
                    user = await query.FirstOrDefaultAsync(user => user.UserName == encryptedRequest.Username, cancellationToken);
                }
                else
                    validationFailures.Add(user, new NullReferenceException("User name not specified"), "Username");

                if (!string.IsNullOrEmpty(request.EmailAddress))
                {
                    user = await query.FirstOrDefaultAsync(user => user.EmailAddress == encryptedRequest.EmailAddress, cancellationToken);
                }
                else
                    validationFailures.Add(user, new NullReferenceException("Email address not specified"), "EmailAddress");

                if (user != null)
                    return modelEncryptor.Decrypt(user);
                else
                    validationFailures.Add(user, new NullReferenceException("User not found"), "User");

                return user;
            }

            
            return this.Response(user => user != null && user.Id != Guid.Empty, ResponseHandler);
        }
    }
}
