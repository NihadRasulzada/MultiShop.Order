using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository 
    {
        private readonly OrderContext _context;

        public AddressRepository(OrderContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Address?> GetByUserIdAsync(string id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}
