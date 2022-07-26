﻿using HotelReservation.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Domain.Mappings.Bookings
{
    public class BookingMapping : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasOne(p => p.User)
                .WithMany(p => p.Bookings)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(p => p.HotelRoom)
                .WithMany(p => p.Bookings)
                .HasForeignKey(x => x.HotelRoomId);

            builder.Property(p => p.Room).HasMaxLength(20);
            builder.Property(p => p.FirstName).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(2000);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();  
        }
    }
}
