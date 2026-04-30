using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.Data;
using CityBike.Models;

namespace CityBike.Services
{
    public class AuthService
    {
        private readonly AppDBContext _db;

        public AuthService(AppDBContext db)
        {
            _db = db;
        }

        // Login
        public string Login(string email, string password)
        {
            var user = _db.Riders.FirstOrDefault(rider => rider.Email == email && rider.Password == password);
            if (user == null) { return null; }
            if (user.IsBlocked) { return null; }
          
            if (user.Password != password)
            {
                user.FailedLoginAttempts++;
                if (user.FailedLoginAttempts >= 3)
                {
                    user.IsBlocked = true;
                }
                _db.SaveChanges();
                return null;
            }

            var token = new Token(user.Id);
            _db.Tokens.Add(token);
            _db.SaveChanges();
            return token.AccessToken;
        }
        // Register
        public bool Register(string email, string password, string name, string city)
        {
            var user = _db.Riders.FirstOrDefault(rider => rider.Email == email && rider.Password == password);
            if (user != null) {return false;}

            var newRider = new Rider
            {
                Email = email,
                Password = password,
                Name = name,
                City = city,
                FailedLoginAttempts = 0,
                IsBlocked = false,
            };
            _db.Riders.Add(newRider);
            _db.SaveChanges();
            return true;
        }

        // VerifyUser
        public bool VerifyUser(string email, string password)
        {
            var user = _db.Riders.FirstOrDefault(rider => rider.Email == email);
            if (user == null) { return false; }
            if (user.IsBlocked) { return false; }

            if (user.Password != password)
            {
                user.FailedLoginAttempts++;
                if (user.FailedLoginAttempts >= 3)
                {
                    user.IsBlocked = true;
                }
                _db.SaveChanges();
                return false;
            }

            user.FailedLoginAttempts = 0;
            _db.SaveChanges();
            return true;
        }
    }
}