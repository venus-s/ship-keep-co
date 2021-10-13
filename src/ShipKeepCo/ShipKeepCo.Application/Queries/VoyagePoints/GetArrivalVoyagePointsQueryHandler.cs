using MediatR;
using ShipKeepCo.Application.Interfaces;
using ShipKeepCo.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipKeepCo.Application.Queries.VoyagePoints
{
    public class GetArrivalVoyagePointsQueryHandler : IRequestHandler<GetArrivalVoyagePointsQuery, List<VoyagePointModel>>
    {
        private readonly IShipKeepCoRepository _shipKeepCoRepository;

        public GetArrivalVoyagePointsQueryHandler(IShipKeepCoRepository shipKeepCoRepository)
        {
            _shipKeepCoRepository = shipKeepCoRepository;
        }

        public async Task<List<VoyagePointModel>> Handle(GetArrivalVoyagePointsQuery request, CancellationToken cancellationToken)
        {
            return await _shipKeepCoRepository.GetArrivalVoyagePointsAsync(request.DepartureDate, request.VoyageId);
        }
    }
}
