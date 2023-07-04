using Microsoft.EntityFrameworkCore;
using MyDevice.Entities;

namespace MyDevice.Context;

public class DeviceAppContext : DbContext
{
    public DbSet<Device> Devices => Set<Device>();
    public DeviceAppContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=device_db;User Id=postgres;Password=postgres;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>();
    }
}
