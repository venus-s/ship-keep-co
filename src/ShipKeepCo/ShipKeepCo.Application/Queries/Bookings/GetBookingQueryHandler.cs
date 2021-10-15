using MediatR;
using ShipKeepCo.Application.Interfaces;
using ShipKeepCo.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ShipKeepCo.Application.Queries.Bookings
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingModel>
    {
        private readonly IShipKeepCoRepository _shipKeepCoRepository;

        public GetBookingQueryHandler(IShipKeepCoRepository shipKeepCoRepository)
        {
            _shipKeepCoRepository = shipKeepCoRepository;
        }

        public async Task<BookingModel> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            return await _shipKeepCoRepository.GetBookingAsync(request.HashId);
        }
    }
}
