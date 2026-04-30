using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityBike.Models
{
    public class Booking
    {
        public int Id { get; set; }
        
        public int RiderId { get; set; }

        [ForeignKey("RiderId")]
        public Rider rider { get; set; }
        
        public int BikeId { get; set; }

        [ForeignKey("BikeId")]
        public Bike bike { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
        public int? DurationInMinutes { get; set; }

        public decimal? Fee { get; set; }

        public bool IsActive { get; set; } = true;
    }
}