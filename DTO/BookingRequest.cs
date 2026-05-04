using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityBike.DTO
{
    public struct BookingRequest
    {
        public BookingRequest()
        {
        }

        [Required]
        public int RiderId { get; set; }
        [Required]
        public int BikeId { get; set; }
        public DateTime? EndTime { get; set; }
        public Decimal? Fee { get; set; }
        public bool IsActive { get; set; } = true;
    }
}