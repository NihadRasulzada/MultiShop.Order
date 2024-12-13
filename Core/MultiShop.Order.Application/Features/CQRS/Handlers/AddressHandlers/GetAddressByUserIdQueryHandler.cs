using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByUserIdQueryHandler
    {
        private readonly IAddressRepository _repository;
        public GetAddressByUserIdQueryHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByUserIdQueryResult?> Handle(GetAddressByUserIdQuery query)
        {
            Address address = await _repository.GetByUserIdAsync(query.Id);
            if (address == null)
            {
                return null;
            }
            return new GetAddressByUserIdQueryResult
            {
                Id = address.Id,
                UserId = address.UserId,
                Name = address.Name,
                Surname = address.Surname,
                Email = address.Email,
                Phone = address.Phone,
                Country = address.Country,
                District = address.District,
                City = address.City,
                Detail1 = address.Detail1,
                Detail2 = address.Detail2,
                Description = address.Description,
                ZipCode = address.ZipCode
            };
        }
    }
}
