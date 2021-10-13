using MediatR;
using System;
using System.Collections.Generic;

namespace ShipKeepCo.Application.Queries.DepartureDates
{
    public class GetDepartureDatesQuery : IRequest<List<DateTime>>
    { }
}
