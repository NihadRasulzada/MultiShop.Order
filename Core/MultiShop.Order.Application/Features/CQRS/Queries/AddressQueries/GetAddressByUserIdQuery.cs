using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByUserIdQuery
    {
        public string Id { get; set; }
        public GetAddressByUserIdQuery(string id)
        {
            Id = id;
        }
    }
}
