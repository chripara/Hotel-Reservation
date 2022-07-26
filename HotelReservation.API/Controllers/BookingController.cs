﻿using AutoMapper;
using HotelReservation.AppConstants;
using HotelReservation.Application.AppConstants;
using HotelReservation.Application.Dto.Booking;
using HotelReservation.Application.Dto.Bookings;
using HotelReservation.Domain.Models;
using HotelReservation.Domain.Models.Auth;
using HotelReservation.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Serilog;

namespace HotelReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookingController(
            AppDbContext context,

            IMapper mapper
            ) 
        {
            _mapper = mapper;
            _context = context; 
        }

        [HttpGet]
        [Route("GetBooking")]
        [Authorize(Roles = RoleConstants.RoleAdmin + "," + RoleConstants.RoleUser)]
        public async Task<IActionResult> GetBooking(GetBookingDto dto)
        {
            Log.Information("GetBookingDto: {@GetBookingDto}", FilterDto(JObject.FromObject(dto)));

            var booking = await _context.Bookings.Include(i => i.User).FirstOrDefaultAsync(f => f.Id == dto.Id);

            var loggedUser = User.Identity.Name;

            if (booking.User.UserName != loggedUser)
            
            Log.Information("Bookings : {@Booking}", FilterDto(JObject.FromObject(booking)));
            return Ok(booking);
        }

        [HttpDelete]
        [Authorize(Roles = RoleConstants.RoleAdmin + "," + RoleConstants.RoleUser)]
        [Route("DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(DeleteBookingDto dto)
        {
            Log.Information("DeleteBookingDto: {@DeleteBookingDto}", FilterDto(JObject.FromObject(dto)));
            
            var booking = await _context.Bookings.FindAsync(dto.Id);
            
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            Log.Information("Booking Deleted.");
            return Ok("Booking Deleted.");
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.RoleAdmin + "," + RoleConstants.RoleUser)]
        [Route("CreateBookings")]
        public async Task<IActionResult> CreateBookings(CreateBookingDto dto)
        {
            Log.Information("CreateBookingDto: {@CreateBookingDto}", FilterDto(JObject.FromObject(dto)));
            
            var newBooking = _mapper.Map<Booking>(dto);

            _context.Bookings.AddAsync(newBooking);
            await _context.SaveChangesAsync();

            Log.Information("Booking Created.");
            return Ok("Booking Created.");
        }

        [HttpPut]
        [Route("UpdateBooking")]
        [Authorize(Roles = RoleConstants.RoleAdmin + "," + RoleConstants.RoleUser)]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto dto)
        {
            Log.Information("UpdateBookingDto: {@UpdateBookingDto}", FilterDto(JObject.FromObject(dto)));
            
            var booking = await _context.Bookings.FindAsync(dto.Id);
            
            if (booking == null)
            {
                return NotFound();
            }

            _context.Update(_mapper.Map<Booking>(dto));
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Route("GetAllBookingsForHotel")]
        [HttpPost]
        [Authorize(Roles = RoleConstants.RoleAdmin)]
        public async Task<IActionResult> GetAllBookingsForHotelInDate(GetBookingForHotelDto dto)
        {
            Log.Information("GetBookingForHotelDto: {@GetBookingForHotelDto}", FilterDto(JObject.FromObject(dto)));
            
            var bookings = _context.Bookings.Include(i => i.HotelRoom)
                .Include(i => i.HotelRoom.Hotel)
                .Where(w => w.HotelRoom.Hotel.Name == dto.HotelName)
                .ToList();

            return Ok();
        }

        [Route("SeedBookings")]
        [HttpPost]
        [Authorize(Roles = RoleConstants.RoleAdmin + "," + RoleConstants.RoleUser)]
        public async Task<IActionResult> SeedBookings()
        {
            var hotels = _context.Hotels.Include(i => i.HotelRooms).ToList();

            foreach(var hotel in hotels)
            {
                foreach(var hotelRoom in hotel.HotelRooms.ToList())
                {
                    var counterStart = 0;
                    var counterEnd = 0;
                    for(var i=0; i<=RandomNumInt(); i++)
                    {
                        var tempCountStart = RandomNumInt();
                        counterStart += tempCountStart;
                        counterEnd += tempCountStart + RandomNumInt();

                        _context.Bookings.Add(new Booking
                        {
                            Description = "asdfasdf",
                            StartDate = DateTime.Now.AddDays(counterStart),
                            EndDate = DateTime.Now.AddDays(counterEnd),
                            FirstName = "asdfasdf",
                            HotelRoomId = hotelRoom.Id,
                            LastName = "asdfasdf",
                            Room = "asdf",
                            UserId = 5,
                        });

                        await _context.SaveChangesAsync();
                    }
                }
            }

            return Ok();
        }

        private int RandomNumInt()
        {
            var randomGenerator = new Random();

            return randomGenerator.Next(1,5);
        }

        private string FilterDto(JObject dto)
        {
            dto.Remove("Password");
            dto.Remove("Token");
            dto.Remove("ConfirmPassword");
            dto.Remove("NewPassword");
            dto.Remove("ConfirmNewPassword");
            
            return dto.ToString();
        }
    }
}
