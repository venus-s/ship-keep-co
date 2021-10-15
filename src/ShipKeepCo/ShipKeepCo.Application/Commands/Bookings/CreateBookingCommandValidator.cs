using FluentValidation;
using ShipKeepCo.Application.Interfaces;

namespace ShipKeepCo.Application.Commands.Bookings
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator(IShipKeepCoRepository shipKeepCoRepository)
        {
            RuleFor(b => b)
                .MustAsync(async (b, cancellationToken) => await shipKeepCoRepository.IsValidVoyageAsync(b.DepartureVoyagePointId, b.ArrivalVoyagePointId))
                    .WithMessage("Invalid Voyage");

            RuleFor(b => b.CustomerFirstName)
                .MaximumLength(64)
                .WithMessage("Customer First Name must be less than 64 characters.");

            RuleFor(b => b.CustomerLastName)
                .MaximumLength(64)
                .WithMessage("Customer Last Name must be less than 64 characters.");
        }
    }
}
