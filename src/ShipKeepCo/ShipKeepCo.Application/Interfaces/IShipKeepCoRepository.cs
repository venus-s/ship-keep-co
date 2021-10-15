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
        /// Gets the booking.
        /// </summary>
        /// <param name="hashId">The hash of the booking id.</param>
        /// <returns>The booking.</returns>
        Task<BookingModel> GetBookingAsync(string hashId);

        /// <summary>
        /// Gets the current price per night.
        /// </summary>
        /// <returns>The price per night.</returns>
        Task<PricePerNightModel> GetPricePerNightAsync();

        /// <summary>
        /// Gets the voyage points.
        /// </summary>
        /// <returns>The available departure voyage points.</returns>
        Task<List<VoyagePointModel>> GetVoyagePointsAsync();

        /// <summary>
        /// Determines if the departure is before the arrival.
        /// </summary>
        /// <param name="departureVoyagePointId">The departure voyage point id.</param>
        /// <param name="arrivalVoyagePointId">The arrival voyage point id.</param>
        /// <returns>Whether the departure is before the arrival.</returns>
        Task<bool> IsValidVoyageAsync(int departureVoyagePointId, int arrivalVoyagePointId);
    }
}
