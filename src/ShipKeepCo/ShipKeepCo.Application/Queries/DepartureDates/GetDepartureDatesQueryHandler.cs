using MediatR;
using ShipKeepCo.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShipKeepCo.Application.Queries.DepartureDates
{
    public class GetDepartureDatesQueryHandler : IRequestHandler<GetDepartureDatesQuery, List<DateTime>>
    {
        private readonly IShipKeepCoRepository _shipKeepCoRepository;
        
        public GetDepartureDatesQueryHandler(IShipKeepCoRepository shipKeepCoRepository)
        {
            _shipKeepCoRepository = shipKeepCoRepository;
        }

        public async Task<List<DateTime>> Handle(GetDepartureDatesQuery request, CancellationToken cancellationToken)
        {
            return await _shipKeepCoRepository.GetAvailableDepartureDates();
        }
    }
}
