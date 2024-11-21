using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand request)
        {
            await _repository.CreateAsync(new Address
            {
                UserId = request.UserId,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Phone = request.Phone,
                Country = request.Country,
                District = request.District,
                City = request.City,
                Detail1 = request.Detail1,
                Detail2 = request.Detail2,
                Description = request.Description,
                ZipCode = request.ZipCode
            });
        }
    }
}
