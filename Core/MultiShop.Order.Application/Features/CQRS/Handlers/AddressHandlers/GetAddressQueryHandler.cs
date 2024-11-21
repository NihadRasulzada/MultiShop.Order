using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System.Net;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;
        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            List<Address> addresses = await _repository.GetAllAsync();
            return addresses.Select(address => new GetAddressQueryResult
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
            }).ToList();
        }
    }
}
