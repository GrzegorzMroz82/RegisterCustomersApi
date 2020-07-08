using GameTek.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTek.Services.Users.Queries
{
    public class GetCustomersForBrandQuery : IRequest<IEnumerable<CustomerData>>
    {
        public string BrandId { get; }
        public GetCustomersForBrandQuery(string brandId)
        {
            BrandId = brandId;
        }
    }


    public class GetCustomersForBrandQueryHandler : IRequestHandler<GetCustomersForBrandQuery, IEnumerable<CustomerData>>
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomersForBrandQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerData>> Handle(GetCustomersForBrandQuery request, CancellationToken cancellationToken)
        {
            var branCustomers = await  customerRepository.GetAllForBrand(request.BrandId);

            return branCustomers.Select(x => x.Content);
        }
    }
}
