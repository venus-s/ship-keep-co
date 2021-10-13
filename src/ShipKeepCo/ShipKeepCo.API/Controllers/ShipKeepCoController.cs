using Microsoft.AspNetCore.Mvc;
using ShipKeepCo.API.Models;
using ShipKeepCo.Application.Commands.Bookings;
using ShipKeepCo.Application.Models;
using ShipKeepCo.Application.Queries.DepartureDates;
using ShipKeepCo.Application.Queries.VoyagePoints;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShipKeepCo.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ShipKeepCoController : ApiControllerBase
    {
        [HttpPost("Bookings")]
        public async Task<ActionResult<BookingModel>> CreateArea(CreateBookingModel booking)
        {
            return await Mediator.Send(new CreateBookingCommand(
                booking.CustomerFirstName,
                booking.CustomerLastName,
                booking.DepartureVoyagePointId,
                booking.ArrivalVoyagePointId));
        }

        [HttpGet("DepartureDates")]
        public async Task<ActionResult<List<DateTime>>> GetDepartureDates()
        {
            return await Mediator.Send(new GetDepartureDatesQuery());
        }

        [HttpGet("VoyagePoints/{date}")]
        public async Task<ActionResult<List<VoyagePointModel>>> GetVoyagePoints(DateTime date)
        {
            return await Mediator.Send(new GetVoyagePointsQuery(date));
        }

        [HttpGet("ArrivalVoyagePoints")]
        public async Task<ActionResult<List<VoyagePointModel>>> GetArrivalVoyagePoints(GetArrivalVoyagePointsModel model)
        {
            return await Mediator.Send(new GetArrivalVoyagePointsQuery(model.DepartureDate, model.VoyageId));
        }
    }
}
