using MediatR;
using ShipKeepCo.Application.Models;

namespace ShipKeepCo.Application.Queries.Bookings
{
    public class GetBookingQuery : IRequest<BookingModel>
    {
        public string HashId { get; }

        public GetBookingQuery(string hashId)
        {
            HashId = hashId;
        }
    }
}
