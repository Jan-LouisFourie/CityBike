using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.Models;

namespace CityBike.Services
{
    public class RiderService
    {
        private readonly List<Rider> riders = [
            new Rider { Id = 1, Name = "Alice Smith", Email = "alice.smith@example.com", Password = "password123", City = "New York" },
            new Rider { Id = 2, Name = "Bob Johnson", Email = "bob.johnson@example.com", Password = "securepass", City = "Los Angeles" },
            new Rider { Id = 3, Name = "Charlie Brown", Email = "charlie.brown@example.com", Password = "charliepass", City = "Chicago" },
            new Rider { Id = 4, Name = "Diana Prince", Email = "diana.prince@example.com", Password = "dianapass", City = "Houston" },
            new Rider { Id = 5, Name = "Ethan Hunt", Email = "ethan.hunt@example.com", Password = "ethanpass", City = "Phoenix" }
        ];

        public Rider GetById(int riderId)
        {
            return riders.FirstOrDefault(r => r.Id == riderId);
        }
    }
}