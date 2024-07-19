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
            Address address = await _repository.GetByIdAsync(request.AddressId);
            address.City = request.City;
            address.UserId = request.UserId;
            address.Detail = request.Detail;
            address.District = request.District;
            await _repository.UpdateAsync(address);
        }
    }
}
