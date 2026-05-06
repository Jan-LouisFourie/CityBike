using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CityBike.Services
{
    public class ReportService(BookingService bookingService) : ControllerBase
    {
        private readonly BookingService bookingService = bookingService;

        public RevenueReport GenerateRevenueReport(DateTime startDate, DateTime endDate)
        {
            var bookings = bookingService.GetBookings()
            .Where(b => b.StartTime >= startDate && b.EndTime <= endDate && !b.IsActive)
            .ToList();
            
            decimal totalRevenue = bookings.Sum(b => b.Fee ?? 0m);
            int totalBookings = bookings.Count;

            decimal averageRevenuePerBooking = totalBookings > 0 ? totalRevenue / totalBookings : 0m;

            return new RevenueReport
            {
                TotalRevenue = totalRevenue,
                TotalBookings = totalBookings,
                AverageRevenuePerBooking = averageRevenuePerBooking
            };
        }
    }
}