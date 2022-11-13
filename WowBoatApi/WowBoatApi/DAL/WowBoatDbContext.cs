using Microsoft.EntityFrameworkCore;

namespace WowBoatApi.DAL;

public class WowBoatDbContext : DbContext
{
    public DbSet<BoatInformation> BoatsInformation { get; set; }
    
    public DbSet<BoatImage> BoatImages { get; set; }
    
    public DbSet<BoatType> BoatTypes { get; set; }
    
    public DbSet<BoatLocation> BoatLocations { get; set; }
    
    public DbSet<BoatBenefit> BoatBenefits { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost;Database=WowBoats;Trusted_Connection=True;Encrypt=false");
    }
}