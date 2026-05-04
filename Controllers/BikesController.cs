using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.Models;
using CityBike.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityBike.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BikesController(BikeService bikeService) : ControllerBase
    {
        private readonly BikeService bikeService = bikeService;

        [HttpGet("available")]
        public IActionResult GetAvailable([FromQuery] string city)
        {
            var bikes = bikeService.GetAvailableBikes(city);
            return bikes.Count > 0 ? Ok(bikes) : NotFound("No bikes available");
        }

    }
}