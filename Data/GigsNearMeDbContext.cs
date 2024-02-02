using Microsoft.EntityFrameworkCore;
using GigsNearMe.Models;

namespace GigsNearMe.Data
{
    public class GigsNearMeDbContext : DbContext
    {
        public GigsNearMeDbContext(DbContextOptions<GigsNearMeDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Gig> Gigs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Artist>().HasData(SeedData.Artists);
            builder.Entity<Venue>().HasData(SeedData.Venues);
            builder.Entity<Tour>().HasData(SeedData.Tours);
            builder.Entity<Gig>().HasData(SeedData.Gigs);
        }
        
    }
}