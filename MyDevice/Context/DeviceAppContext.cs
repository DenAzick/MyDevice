using Microsoft.EntityFrameworkCore;
using MyDevice.Entities;

namespace MyDevice.Context;

public class DeviceAppContext : DbContext
{
    public DbSet<Device> Devices { get; set; }
    public DeviceAppContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=tutorial;User Id=postgres;Password=postgres;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>();
    }
}
