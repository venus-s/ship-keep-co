using MediatR;
using ShipKeepCo.Application.Models;

namespace ShipKeepCo.Application.Commands.Bookings
{
    public class CreateBookingCommand : IRequest<BookingModel>
    {
        public string CustomerFirstName { get; }

        public string CustomerLastName { get; }

        public int DepartureVoyagePointId { get; }

        public int ArrivalVoyagePointId { get; }

        public CreateBookingCommand(
            string customerFirstName,
            string customerLastName,
            int departureVoyagePointId,
            int arrivalVoyagePointId)
        {
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            DepartureVoyagePointId = departureVoyagePointId;
            ArrivalVoyagePointId = arrivalVoyagePointId;
        }
    }
}
