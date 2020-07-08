using GameTek.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTek.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        Dictionary<string, List<CustomerEnity>> storageDict = new Dictionary<string, List<CustomerEnity>>();

        public async Task AddCustomer(string brandId, CustomerData customer)
        {
            if (!storageDict.ContainsKey(brandId))
            {
                storageDict.Add(brandId, new List<CustomerEnity>());
            }
            storageDict[brandId].Add(new CustomerEnity { Id = Guid.NewGuid().ToString(), Content = customer  });
        }

        public async Task<CustomerEnity> FindCustomerUsingData(string brandId, CustomerData customer)
        {
            if (!storageDict.ContainsKey(brandId))
            {
                return null;
            }
            return storageDict[brandId].FirstOrDefault(x => x.Content.Equals(customer));
        }

        public async Task<IEnumerable<CustomerEnity>> GetAllForBrand(string brandId)
        {
            var res = storageDict.ContainsKey(brandId) ? storageDict[brandId].ToList() : new List<CustomerEnity>();
            return res;
        }
    }
}
