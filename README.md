# CityBike Rental Management API
### SDT621 — Software Design & Testing with C# | Guided Class Exercise

---

## Overview

This is a deliberately **buggy** .NET 8 Web API built for the SDT621 guided class exercise.
Your job as a Junior Software Tester is to:

1. Design a test plan and test cases
2. Execute functional and non-functional tests using Postman
3. Find and document the 5 intentional bugs
4. Fix the bugs and verify the corrections

---

## Setup Instructions

### Prerequisites
| Tool | Download |
|------|----------|
| .NET 8 SDK | https://dotnet.microsoft.com/download/dotnet/8 |
| Visual Studio 2022 (Community) | https://visualstudio.microsoft.com/ |
| Postman | https://www.postman.com/downloads/ |
| Git | https://git-scm.com/ |

### Running the API

**Option A — Visual Studio**
1. Open `CityBikeAPI.sln` in Visual Studio 2022
2. Press **F5** to run (or Ctrl+F5 for without debugger)
3. The API starts on `http://localhost:5000`

**Option B — Command Line**
```bash
cd CityBikeAPI
dotnet run
```

### Verifying the API is Running
Open a browser or Postman and send:
```
GET http://localhost:5000/
```
You should receive a JSON response listing all endpoints, seed accounts, and the bugs to find.

---

## API Endpoints

| Method | Endpoint | Auth Required | Description |
|--------|----------|---------------|-------------|
| POST | `/api/auth/register` | None | Register a new rider |
| POST | `/api/auth/login` | None | Login (returns token) |
| GET  | `/api/auth/me` | Rider | Verify your token |
| GET  | `/api/bikes/available` | None | List available bikes (`?city=` optional) |
| POST | `/api/bookings` | Rider | Create a booking |
| PUT  | `/api/bookings/{id}/return` | Rider | Return a bike |
| GET  | `/api/bookings/{id}` | Rider/Admin | Get booking details |
| GET  | `/api/reports/revenue` | Admin only | Revenue report |

### Authentication
After logging in, copy the `token` value from the response and add it to your Postman requests:
- Header name: `Authorization`
- Header value: `Bearer <paste your token here>`

---

## Seed Accounts

| Email | Password | Role | Notes |
|-------|----------|------|-------|
| admin@citybike.co.za | Admin@1234 | admin | Can access revenue reports |
| sipho@test.com | Sipho@123 | rider | Normal rider account |
| amahle@test.com | Amahle@123 | rider | Already has an active booking |
| locked@test.com | Locked@123 | rider | Account is locked |

---

## Bugs to Find (DEF-001 to DEF-005)

> **Do not read this section until instructed by your lecturer.**
> Try to discover the bugs through testing first!

<details>
<summary>Click to reveal bug locations (for marking/reference only)</summary>

| Bug ID | File | Line | Description |
|--------|------|------|-------------|
| DEF-001 | `DTOs/DTOs.cs` | RegisterRequest.Password | `MinLength(1)` should be `MinLength(8)` |
| DEF-002 | `Services/AuthService.cs` | Login() method | `rider.FailedLoginAttempts++` missing; `IsLocked` never set |
| DEF-003 | `Services/BookingService.cs` | CreateBooking() | `b.Status != "active"` should be `b.Status == "active"` |
| DEF-004 | `Services/ReportService.cs` | GetRevenue() | No null check before `DateTime.Parse(startDate!)` |
| DEF-005 | `Services/BookingService.cs` | CalculateFee() | `5.00m / durationMinutes` should be `5.00m * durationMinutes` |

</details>

---

## Project Structure

```
CityBikeAPI/
├── Controllers/
│   ├── AuthController.cs       # POST /api/auth/register, /api/auth/login, GET /api/auth/me
│   ├── BikesController.cs      # GET /api/bikes/available
│   ├── BookingsController.cs   # POST/GET/PUT /api/bookings
│   └── ReportsController.cs    # GET /api/reports/revenue
├── Data/
│   └── DataStore.cs            # In-memory data store + seed data
├── DTOs/
│   └── DTOs.cs                 # Request/Response shapes (DEF-001 is here)
├── Middleware/
│   └── TokenAuthMiddleware.cs  # Token parsing
├── Models/
│   └── Models.cs               # Rider, Bike, Booking entities
├── Services/
│   ├── AuthService.cs          # Registration + login logic (DEF-002 is here)
│   ├── BikeService.cs          # Bike availability logic
│   ├── BookingService.cs       # Booking creation + fee calculation (DEF-003, DEF-005)
│   └── ReportService.cs        # Revenue report logic (DEF-004 is here)
├── Program.cs                  # Startup, DI, middleware pipeline
└── CityBikeAPI.csproj
```

---

## Sample Postman Requests

### Register a Rider
```json
POST http://localhost:5000/api/auth/register
Content-Type: application/json

{
  "fullName": "Test Rider",
  "email": "testrider@example.com",
  "password": "MyPass@99",
  "city": "Cape Town"
}
```

### Login
```json
POST http://localhost:5000/api/auth/login
Content-Type: application/json

{
  "email": "sipho@test.com",
  "password": "Sipho@123"
}
```

### Create a Booking
```json
POST http://localhost:5000/api/bookings
Authorization: Bearer <your token>
Content-Type: application/json

{
  "bikeId": 1,
  "startStation": "V&A Waterfront"
}
```

### Return a Bike
```json
PUT http://localhost:5000/api/bookings/1001/return
Authorization: Bearer <your token>
Content-Type: application/json

{
  "returnStation": "Gardens"
}
```

### Get Revenue Report (admin only)
```
GET http://localhost:5000/api/reports/revenue?startDate=2026-04-01&endDate=2026-04-30
Authorization: Bearer <admin token>
```

---

## Notes for Students

- Data is **in-memory** — it resets every time you restart the API. This is by design.
- The token format is a simple base64 string, not a real JWT. In production you would use `Microsoft.AspNetCore.Authentication.JwtBearer`.
- The password hashing uses SHA-256 + a fixed salt — not production-grade. Real apps use BCrypt or Argon2.
- There is no database — the `DataStore` class acts as the repository. This keeps setup simple for class exercises.

---

*CTU Training Solutions | SDT621 Software Design & Testing with C# | 2026*
