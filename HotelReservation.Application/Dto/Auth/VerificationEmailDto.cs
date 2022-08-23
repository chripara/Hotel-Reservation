﻿using Destructurama.Attributed;
using HotelReservation.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Dto.Auth
{
    public class VerificationEmailDto : IEntityDto
    {
        [LogMasked]
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
