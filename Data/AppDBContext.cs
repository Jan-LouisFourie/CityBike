using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CityBike.Models;

namespace CityBike.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Bike> Bikes {get; set;}
        public DbSet<Rider> Riders {get; set;}
        public DbSet<Booking> Bookings {get; set;}
        public DbSet<Token> Tokens {get; set;}


    }
}