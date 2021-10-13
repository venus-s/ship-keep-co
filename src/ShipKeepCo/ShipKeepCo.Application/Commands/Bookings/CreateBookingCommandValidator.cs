using FluentValidation;
using ShipKeepCo.Application.Interfaces;

namespace ShipKeepCo.Application.Commands.Bookings
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator(IShipKeepCoRepository shipKeepCoRepository)
        {
            RuleFor(b => b)
                .MustAsync(async (b, cancellationToken) => await shipKeepCoRepository.IsDepartureBeforeArrival(b.DepartureVoyagePointId, b.ArrivalVoyagePointId));
        }
    }
}
