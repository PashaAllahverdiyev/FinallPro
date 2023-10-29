using Hotel.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataAccess;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {}
    public DbSet<Bathroom> Bathrooms { get; set; }
    public DbSet<HotelDetail> HotelDetails { get; set; }
    public DbSet<Hotell> Hotels { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomDetail> RoomDetails { get; set; }
    public DbSet<RoomLandScape> RoomLandScapes { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<RoomSize> RoomSizes { get; set; }

}
