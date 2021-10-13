using MediatR;
using ShipKeepCo.Application.Interfaces;
using ShipKeepCo.Application.Models;
using ShipKeepCo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ShipKeepCo.Application.Commands.Bookings
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingModel>
    {
        private readonly IShipKeepCoRepository _shipKeepCoRepository;

        public CreateBookingCommandHandler(IShipKeepCoRepository shipKeepCoRepository)
        {
            _shipKeepCoRepository = shipKeepCoRepository;
        }

        public async Task<BookingModel> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Booking()
            {
                CustomerFirstName = request.CustomerFirstName,
                CustomerLastName = request.CustomerLastName,
                DepartureVoyagePointId = request.DepartureVoyagePointId,
                ArrivalVoyagePointId = request.ArrivalVoyagePointId,
            };

            return await _shipKeepCoRepository.CreateBookingAsync(booking);
        }
    }
}
