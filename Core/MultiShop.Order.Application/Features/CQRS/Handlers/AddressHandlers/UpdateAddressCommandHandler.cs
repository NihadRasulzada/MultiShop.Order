using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand request)
        {
            Address address = await _repository.GetByIdAsync(request.Id);
            address.Name = request.Name;
            address.Surname = request.Surname;
            address.Email = request.Email;
            address.Phone = request.Phone;
            address.Country = request.Country;
            address.City = request.City;
            address.UserId = request.UserId;
            address.Detail1 = request.Detail1;
            address.Detail2 = request.Detail2;
            address.Description = request.Description;
            address.District = request.District;
            address.ZipCode = request.ZipCode;
            await _repository.UpdateAsync(address);
        }
    }
}
