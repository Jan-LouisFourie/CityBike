using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.Models;

namespace CityBike.Services
{
    public class BookingService
    {
        private List<Booking> _bookings = new List<Booking>();

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
            var booking = _bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking != null)
            {
                booking.IsActive = false;
                booking.EndTime = DateTime.Now;
                booking.DurationInMinutes = (int?)(booking.EndTime - booking.StartTime).Value.TotalMinutes;
                booking.Fee = (decimal)(DateTime.Now - booking.EndTime.Value).TotalHours * 5; // Example fee calculation
            }
            return booking;
        }

        public List<Booking> GetBookings()
        {
            return _bookings;
        }
    }
}