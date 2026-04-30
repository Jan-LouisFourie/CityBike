using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.DTO;
using CityBike.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityBike.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        private readonly AuthService authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result =  authService.Register(request.Email, request.Password, request.Name, request.City);
            if (result)
            {
                return Created("New User Registered Successfully", null);
            } else
            {
                return BadRequest("User with this email already exists");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = authService.Login(request.Email, request.Password);
            if (result != null)
            {
                return Ok(new { AccessToken = result });
            } else
            {
                return BadRequest("User does not exist or is blocked due to multiple failed login attempts");
            }
        }

    }
}