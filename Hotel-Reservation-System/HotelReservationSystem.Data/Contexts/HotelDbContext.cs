using HotelReservationSystem.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Data.Contexts
{
    public class HotelDbContext : IdentityDbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Decimal Hassasiyet Yapılandırmaları
            modelBuilder.Entity<Room>()
                .Property(r => r.NightlyPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Reservation>()
                .Property(res => res.TotalAmount)
                .HasPrecision(18, 2);

            // Unique Constraint Tanımlamaları
            modelBuilder.Entity<Manager>()
                .HasIndex(m => m.Email)
                .IsUnique();

            modelBuilder.Entity<Guest>()
                .HasIndex(g => g.IdentityNumber)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
