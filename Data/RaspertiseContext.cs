using Raspertise.Models;
using Microsoft.EntityFrameworkCore;

namespace Raspertise.Data {

    public class RaspertiseContext : DbContext {

        public RaspertiseContext(DbContextOptions<RaspertiseContext> options) : base(options) {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=raspertise.db");
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }

        /***
         * This method overrides the table names in the database so they can be singular instead of plural
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<Advertisement>().ToTable("Advertisement");
            modelBuilder.Entity<Sponsor>().ToTable("Sponsor");
            modelBuilder.Entity<Advertiser>().ToTable("Advertiser");
        }

    }

}