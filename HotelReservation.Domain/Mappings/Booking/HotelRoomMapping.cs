﻿using HotelReservation.Domain.Models.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Domain.Mappings.Bookings
{
    public class HotelRoomMapping : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder.HasOne(x => x.Hotel)
                .WithMany(x => x.HotelRooms)
                .HasForeignKey(x => x.HotelId);

            builder.Property(p => p.RoomNumber).HasMaxLength(10);
            builder.Property(p => p.Capacity).HasMaxLength(4);
            builder.Property(p => p.Cost).HasMaxLength(10);
            builder.Property(p => p.Description).HasMaxLength(2000);            
        }
    }
}
