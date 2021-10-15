using Microsoft.AspNetCore.Mvc;
using ShipKeepCo.API.Models;
using ShipKeepCo.Application.Commands.Bookings;
using ShipKeepCo.Application.Models;
using ShipKeepCo.Application.Queries.VoyagePoints;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShipKeepCo.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ShipKeepCoController : ApiControllerBase
    {
        [HttpPost("Booking")]
        public async Task<ActionResult<BookingModel>> CreateBooking(CreateBookingModel booking)
        {
            return await Mediator.Send(new CreateBookingCommand(
                booking.CustomerFirstName,
                booking.CustomerLastName,
                booking.DepartureVoyagePointId,
                booking.ArrivalVoyagePointId));
        }

        [HttpGet("Booking/Price")]
        public async Task<ActionResult<PricePerNightModel>> GetPricePerNight()
        {
            return await Mediator.Send(new GetPricePerNightQuery());
        }

        [HttpGet("Voyage")]
        public async Task<ActionResult<List<VoyagePointModel>>> GetVoyagePoints()
        {
            return await Mediator.Send(new GetDepartureVoyagePointsQuery());
        }

        [HttpGet("Voyage/{date}")]
        public async Task<ActionResult<List<VoyagePointModel>>> GetVoyagePoints(DateTime date)
        {
            return await Mediator.Send(new GetVoyagePointsQuery(date));
        }

        [HttpGet("Voyage/{voyageId:int}/Arrival/{departureDate}")]
        public async Task<ActionResult<List<VoyagePointModel>>> GetArrivalVoyagePoints(int voyageId, DateTime departureDate)
        {
            return await Mediator.Send(new GetArrivalVoyagePointsQuery(voyageId, departureDate));
        }
    }
}
