using MediatR;
using ShipKeepCo.Application.Interfaces;
using ShipKeepCo.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShipKeepCo.Application.Queries.VoyagePoints
{
    public class GetDepartureVoyagePointsQueryHandler : IRequestHandler<GetDepartureVoyagePointsQuery, List<VoyagePointModel>>
    {
        private readonly IShipKeepCoRepository _shipKeepCoRepository;
        
        public GetDepartureVoyagePointsQueryHandler(IShipKeepCoRepository shipKeepCoRepository)
        {
            _shipKeepCoRepository = shipKeepCoRepository;
        }

        public async Task<List<VoyagePointModel>> Handle(GetDepartureVoyagePointsQuery request, CancellationToken cancellationToken)
        {
            return await _shipKeepCoRepository.GetDepartureVoyagePoints();
        }
    }
}
