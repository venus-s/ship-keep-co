using MediatR;
using ShipKeepCo.Application.Interfaces;
using ShipKeepCo.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ShipKeepCo.Application.Queries.VoyagePoints
{
    public class GetPricePerNightQueryHandler : IRequestHandler<GetPricePerNightQuery, PricePerNightModel>
    {
        private readonly IShipKeepCoRepository _shipKeepCoRepository;

        public GetPricePerNightQueryHandler(IShipKeepCoRepository shipKeepCoRepository)
        {
            _shipKeepCoRepository = shipKeepCoRepository;
        }

        public async Task<PricePerNightModel> Handle(GetPricePerNightQuery request, CancellationToken cancellationToken)
        {
            return await _shipKeepCoRepository.GetPricePerNightAsync();
        }
    }
}
