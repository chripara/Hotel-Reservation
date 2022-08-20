﻿using AutoMapper;
using HotelReservation.Application.Dto.Booking;
using HotelReservation.Application.Dto.Bookings;
using HotelReservation.Domain.Models;
using HotelReservation.Domain.Models.Auth;
using HotelReservation.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
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
        public async Task<IActionResult> GetBooking(GetBookingDto dto)
        {
            var booking = await _context.Bookings.FindAsync(dto.Id);
            return Ok(booking);
        }

        [HttpDelete]
        [Route("DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(DeleteBookingDto dto)
        {
            var booking = await _context.Bookings.FindAsync(dto.Id);
            
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("CreateBookings")]
        public async Task<IActionResult> CreateBookings(CreateBookingDto dto)
        {
            var newBooking = _mapper.Map<Booking>(dto);

            _context.Bookings.AddAsync(newBooking);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto dto)
        {
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
        public async Task<IActionResult> GetAllBookingsForHotel(GetBookingForHotelDto dto)
        {
            var bookings = _context.Bookings.Include(i => i.HotelRooms).Include(i => i.HotelRooms.Hotel).Where(w => w.HotelRoom.Hotel.Name == dto.HotelName).ToList();

            return Ok();
        }
    }
}
