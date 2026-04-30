using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBike.Models
{
    public class Token(int riderId)
    {
        public int Id { get; set; }
        public string AccessToken { get; set; } = new Guid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime Expiration { get; set; } = DateTime.Now.AddHours(24);
        public int RiderId { get; set; } = riderId;
    }
}