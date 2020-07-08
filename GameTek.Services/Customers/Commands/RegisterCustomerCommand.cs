using GameTek.Boundary;
using GameTek.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTek.Services.Customers.Commands
{
    public class RegisterCustomerCommand : IRequest
    {
        public RegisterCustomerCommand(CustomerData customer,string brandId)
        {
            Customer = customer;
            BrandId = brandId;
        }

        public CustomerData Customer { get; }
        public string BrandId { get; }
    }

    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand>
    {
        private readonly IRegisterResponder registerResponder;
        private readonly ICustomerRepository customerRepository;

        public RegisterCustomerCommandHandler(IRegisterResponder registerResponder,ICustomerRepository customerRepository)
        {
            this.registerResponder = registerResponder;
            this.customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {

            var found = await customerRepository.FindCustomerUsingData(request.BrandId, request.Customer);

            if (found != null)
            {
                registerResponder.SetResult(RegisterResult.AlreadyExist);
                return await Unit.Task;
            }

            if (!request.Customer.Validate())
            {
                registerResponder.SetResult(RegisterResult.MissingRequired);
                return await Unit.Task;
            }

            await customerRepository.AddCustomer(request.BrandId, request.Customer);

            registerResponder.SetResult(RegisterResult.Success);
            return await Unit.Task;
        }
    }
}
