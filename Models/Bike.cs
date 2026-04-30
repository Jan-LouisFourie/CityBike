using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.Enums;

namespace CityBike.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string City { get; set; }
        public bool IsAvailable { get; set; } = true;
        public List<Booking> Bookings { get; set; }
        public Status Status { get; set; } = Status.Available;
    }
}