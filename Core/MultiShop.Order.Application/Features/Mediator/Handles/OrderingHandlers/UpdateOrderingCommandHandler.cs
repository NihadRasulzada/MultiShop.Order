using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handles.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;
        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            Ordering ordering = await _repository.GetByIdAsync(request.Id);
            ordering.OrderDate = request.OrderDate;
            ordering.UserId = request.UserId;
            ordering.TotalPrice = request.TotalPrice;
            ordering.AddressId = request.AddressId;
            await _repository.UpdateAsync(ordering);
        }
    }
}
