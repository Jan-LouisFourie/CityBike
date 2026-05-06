using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBike.DTO
{
    public struct RevenueReport
    {
        public decimal TotalRevenue { get; set; }
        public int TotalBookings { get; set; }
        public decimal AverageRevenuePerBooking {get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}