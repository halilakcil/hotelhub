using Hotel.Core.Entities.Concrete;
using Hotel.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataAccess.Concrete.EntityFramework.Contexts
{
    public class HotelHubDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HotelHubDb;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HotelRoom>(entity =>
            {
                entity.HasOne(d => d.HotelInformation)
                    .WithMany(p => p.HotelRoomList)
                    .HasForeignKey(d => d.HotelInformationId)
                    .HasConstraintName("FK_HotelRooms_HotelInformations");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.HotelRoomList)
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK_HotelRooms_RoomTypes");
            });
        }

        public DbSet<HotelInformation> HotelInformations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
