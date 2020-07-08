using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTek.Model
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerEnity>> GetAllForBrand(string brandId);
        Task<CustomerEnity> FindCustomerUsingData(string brandId, CustomerData customer);
        Task AddCustomer(string brandId, CustomerData customer);
    }
}
