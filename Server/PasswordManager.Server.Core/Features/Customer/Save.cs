using AutoMapper;
using DNI.Encryption.Shared.Abstractions;
using DNI.Mediator.Shared.Abstractions;
using DNI.Mediator.Shared.Base;
using DNI.Shared.Abstractions;
using PasswordManager.Shared.Queries.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Models = PasswordManager.Shared.Models.Db;

namespace PasswordManager.Server.Core.Features.Customer
{
    public class Save : IRequestResponseHandler<SaveRequest, Models.Customer>
    {
        private readonly IAsyncRepository<Models.Customer> customerRepository;
        private readonly IModelEncryptor modelEncryptor;
        private readonly IMapper mapper;

        public Save(IAsyncRepository<Models.Customer> customerRepository,
            IModelEncryptor modelEncryptor,
            IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.modelEncryptor = modelEncryptor;
            this.mapper = mapper;
        }

        public async Task<IResponse<Models.Customer>> Handle(SaveRequest request, CancellationToken cancellationToken)
        {
            var newCustomer = mapper.Map<Models.Customer>(request);
            var encryptedCustomer = modelEncryptor.Encrypt(newCustomer);

            customerRepository.Add(encryptedCustomer);

            if (request.Commit)
            {
                await customerRepository.SaveChangesAsync(cancellationToken);
            }

            return Response.Success(encryptedCustomer);
        }
    }
}
