using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.Enums;
using CityBike.Models;

namespace CityBike.Services
{
    public class BikeService
    {
        private readonly List<Bike> bikes = new List<Bike>
        {
            new Bike { Id = 1, Model = "City Cruiser", City = "Prague", IsAvailable = true, Status = Status.Available },
            new Bike { Id = 2, Model = "Urban Explorer", City = "Prague", IsAvailable = true, Status = Status.Available },
            new Bike { Id = 3, Model = "Touring Pro", City = "Prague", IsAvailable = false, Status = Status.InUse },
            new Bike { Id = 4, Model = "E-Bike Lite", City = "Brno", IsAvailable = true, Status = Status.Available },
            new Bike { Id = 5, Model = "City Compact", City = "Brno", IsAvailable = true, Status = Status.Available },
            new Bike { Id = 6, Model = "Sport Rider", City = "Ostrava", IsAvailable = false, Status = Status.Maintenance },
            new Bike { Id = 7, Model = "Comfort Ride", City = "Ostrava", IsAvailable = true, Status = Status.Available },
            new Bike { Id = 8, Model = "Classic Tour", City = "Pilsen", IsAvailable = true, Status = Status.Available },
            new Bike { Id = 9, Model = "Night Shift", City = "Pilsen", IsAvailable = true, Status = Status.Available },
            new Bike { Id = 10, Model = "Weekend Cruiser", City = "Prague", IsAvailable = true, Status = Status.Available }
        };

        public Bike GetById(int bikeId)
        {
            return bikes.FirstOrDefault(b => b.Id == bikeId);
        }

        public List<Bike> GetAvailableBikes(string city)
        {
            return bikes.Where(b => b.IsAvailable && b.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}