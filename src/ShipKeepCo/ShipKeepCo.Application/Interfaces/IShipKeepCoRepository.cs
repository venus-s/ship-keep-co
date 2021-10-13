using ShipKeepCo.Application.Models;
using ShipKeepCo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShipKeepCo.Application.Interfaces
{
    public interface IShipKeepCoRepository
    {
        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        Task<BookingModel> CreateBookingAsync(Booking booking);

        /// <summary>
        /// Gets the available departure dates.
        /// </summary>
        /// <returns>The available departure dates.</returns>
        Task<List<DateTime>> GetAvailableDepartureDates();

        /// <summary>
        /// Gets the voyage points for all of the voyages on a specific date.
        /// </summary>
        /// <param name="dateTime">The date of the voyage point.</param>
        /// <returns>The possible voyage points.</returns>
        Task<List<VoyagePointModel>> GetVoyagePointsAsync(DateTime dateTime);

        /// <summary>
        /// Gets the possible arrival voyage points given a departure date and a voyage id.
        /// </summary>
        /// <param name="departureDate">The departure date.</param>
        /// <param name="voyageId">The id of the voyage.</param>
        /// <returns>The possible arrival voyage points.</returns>
        Task<List<VoyagePointModel>> GetArrivalVoyagePointsAsync(DateTime departureDate, int voyageId);

        /// <summary>
        /// Determines if the departure is before the arrival.
        /// </summary>
        /// <param name="departureVoyagePointId">The departure voyage point id.</param>
        /// <param name="arrivalVoyagePointId">The arrival voyage point id.</param>
        /// <returns>Whether the departure is before the arrival.</returns>
        Task<bool> IsDepartureBeforeArrival(int departureVoyagePointId, int arrivalVoyagePointId);
    }
}
