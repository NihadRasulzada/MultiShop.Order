using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetByUserIdAsync(string id);
    }
}
