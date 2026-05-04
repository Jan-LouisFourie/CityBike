using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.DTO;
using CityBike.Models;
using CityBike.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityBike.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController(BookingService bookingService, BikeService bikeService, RiderService riderService) : ControllerBase
    {
        private readonly BookingService bookingService = bookingService;

        [HttpPost]
        public IActionResult CreateBooking([FromBody] BookingRequest request)
        {
            Bike bike = bikeService.GetById(request.BikeId);
            Rider rider = riderService.GetById(request.RiderId);

            Booking booking = bookingService.CreateBooking(new Booking
            {
                Id = new Random().Next(1, 1000), // Simulate ID generation
                RiderId = request.RiderId,
                BikeId = request.BikeId,
                rider = rider,
                bike = bike,
                EndTime = request.EndTime,
                Fee = request.Fee,
                IsActive = request.IsActive
            });
            return booking != null ? Ok(booking) : BadRequest("Unable to create booking");

        }

        [HttpPut("{id}/return")]
        public IActionResult ReturnBike([FromRoute] int id)
        {
            Booking updatedBooking = bookingService.ReturnBike(id);
            return updatedBooking != null ? Ok(updatedBooking) : NotFound("Booking not found");        
        }
    }
}