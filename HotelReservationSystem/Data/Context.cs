using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelReservationSystem.Data
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
       // public DbSet<RoomFacilities> RoomsFacilities { get; set; }
        public DbSet<RoomOffer> RoomsOffers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HotelReservationSystem;Integrated Security=True;TrustServerCertificate=True").
                LogTo(log => Debug.WriteLine(log), LogLevel.Information).EnableServiceProviderCaching();
        }


    }
}
