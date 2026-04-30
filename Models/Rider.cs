using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.Enums;

namespace CityBike.Models
{
    public class Rider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public int FailedLoginAttempts { get; set; }
        public bool IsBlocked { get; set; }
        public Roles Role { get; set; } = Roles.Rider;

        public List<Booking> Bookings { get; set; }
    }
}