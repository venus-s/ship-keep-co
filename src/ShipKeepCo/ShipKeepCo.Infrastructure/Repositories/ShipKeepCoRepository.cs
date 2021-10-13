using HashidsNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShipKeepCo.Application.Interfaces;
using ShipKeepCo.Application.Models;
using ShipKeepCo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipKeepCo.Infrastructure.Repositories
{
    public class ShipKeepCoRepository : IShipKeepCoRepository
    {
        private readonly Hashids _hashIds;
        private readonly ShipKeepCoContext _context;

        public ShipKeepCoRepository(IConfiguration configuration, ShipKeepCoContext context)
        {
            _context = context;
            _hashIds = new Hashids(
                configuration.GetValue<string>("HashId:Salt"),
                configuration.GetValue<int>("HashId:Length"));
        }

        public async Task<BookingModel> CreateBookingAsync(Booking booking)
        {
            var pricePerNight = await _context.PricePerNights
                .OrderByDescending(p => p.Created)
                .FirstOrDefaultAsync();

            var departureVoyagePoint = await _context.VoyagePoints
                .Include(vp => vp.Location)
                .FirstOrDefaultAsync(vp => vp.VoyagePointId == booking.DepartureVoyagePointId);

            var arrivalVoyagePoint = await _context.VoyagePoints
                .Include(vp => vp.Location)
                .FirstOrDefaultAsync(vp => vp.VoyagePointId == booking.ArrivalVoyagePointId);

            var nights = (arrivalVoyagePoint.Date - departureVoyagePoint.Date).TotalDays;
            booking.TotalPrice = nights * pricePerNight.Price;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return new BookingModel()
            {
                CustomerFirstName = booking.CustomerFirstName,
                CustomerLastName = booking.CustomerLastName,
                TotalPrice = booking.TotalPrice,
                ArrivalDate = arrivalVoyagePoint.Date,
                ArrivalLocation = arrivalVoyagePoint.Location.Name,
                DepartureDate = departureVoyagePoint.Date,
                DepartureLocation = departureVoyagePoint.Location.Name,
                ConfirmationNumber = _hashIds.Encode(booking.BookingId)
            };
        }

        public async Task<List<DateTime>> GetAvailableDepartureDates()
        {
            return await _context.VoyagePoints
                .Select(vp => vp.Date)
                .Distinct()
                .OrderBy(d => d)
                .ToListAsync();
        }

        public async Task<List<VoyagePointModel>> GetVoyagePointsAsync(DateTime dateTime)
        {
            return await _context.VoyagePoints
                .Where(vp => vp.Date == dateTime)
                .Select(vp => new VoyagePointModel()
                {
                    VoyagePointId = vp.VoyagePointId,
                    VoyageId = vp.VoyageId,
                    Date = vp.Date,
                    Location = vp.Location.Name
                })
                .ToListAsync();
        }

        public async Task<List<VoyagePointModel>> GetArrivalVoyagePointsAsync(DateTime departureDate, int voyageId)
        {
            return await _context.VoyagePoints
                .Where(vp => vp.Date > departureDate && vp.VoyageId == voyageId)
                .Select(vp => new VoyagePointModel()
                {
                    VoyagePointId = vp.VoyagePointId,
                    VoyageId = vp.VoyageId,
                    Date = vp.Date,
                    Location = vp.Location.Name
                })
                .OrderBy(vp => vp.Date)
                .ToListAsync();
        }

        public async Task<bool> IsDepartureBeforeArrival(int departureVoyagePointId, int arrivalVoyagePointId)
        {
            var departureVoyagePoint = await _context.VoyagePoints
                .FirstOrDefaultAsync(vp => vp.VoyagePointId == departureVoyagePointId);

            var arrivalVoyagePoint = await _context.VoyagePoints
                .FirstOrDefaultAsync(vp => vp.VoyagePointId == arrivalVoyagePointId);

            return departureVoyagePoint.Date < arrivalVoyagePoint.Date;
        }
    }
}
