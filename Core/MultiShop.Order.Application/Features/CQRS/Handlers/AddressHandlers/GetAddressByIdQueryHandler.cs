using MediatR;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;
        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            Address address = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
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