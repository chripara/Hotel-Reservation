﻿using HotelReservation.Domain.Models.Auth;
using HotelReservation.Domain.Models.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Models
{
    public class Booking : IEntity
    {
        public int Id { get; set; }
        public string Room { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int HotelRoomId { get; set; }
        public HotelRoom HotelRoom { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
