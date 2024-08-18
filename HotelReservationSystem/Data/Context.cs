using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace HotelReservationSystem.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> option) : base(option)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RoomOffer> RoomsOffers { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<HotelStaff> HotelStaff { get; set; }


    }
}
