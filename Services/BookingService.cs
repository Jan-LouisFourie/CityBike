using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.Models;

namespace CityBike.Services
{
    public class BookingService
    {
        public Booking CreateBooking(Booking booking)
        {
            if (booking == null)
            {
                return null;
            }
            _bookings.Add(booking);
            return booking;
        }

        public Booking ReturnBike(int bookingId)
        {
            var booking = _booking.FirstOrDefault(b => b.Id == bookingId);
            if (booking != null)
            {
                booking.IsActive = false;
                booking.EndTime = DateTime.Now;
                booking.DurationInMinutes = (booking.EndTime - booking.StartTime).Value.TotalMinutes;
                booking.Fee = (decimal)(DateTime.Now - booking.EndTime.Value).TotalHours * 5; // Example fee calculation
            }
            return booking;
        }
    }
}