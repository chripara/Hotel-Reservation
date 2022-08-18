﻿using Generic.Domain.Models.Auth;
using Generic.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Generic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public HotelController(AppDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //[Route("GetAllHotels")]
        //[Route("GetAvailablilityForHotel")]
        //[Route("GetDetailsForHotel")]
        //[Route("GetHotels")]
        //[Route("GetHotelsWithOffers")]

    }
}
