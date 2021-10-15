using MediatR;
using ShipKeepCo.Application.Interfaces;
using ShipKeepCo.Application.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShipKeepCo.Application.Queries.Voyages
{
    public class GetVoyagePointsQueryHandler : IRequestHandler<GetVoyagePointsQuery, List<VoyagePointModel>>
    {
        private readonly IShipKeepCoRepository _shipKeepCoRepository;
        
        public GetVoyagePointsQueryHandler(IShipKeepCoRepository shipKeepCoRepository)
        {
            _shipKeepCoRepository = shipKeepCoRepository;
        }

        public async Task<List<VoyagePointModel>> Handle(GetVoyagePointsQuery request, CancellationToken cancellationToken)
        {
            return await _shipKeepCoRepository.GetVoyagePointsAsync();
        }
    }
}
