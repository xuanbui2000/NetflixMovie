using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlantShop.Models;

namespace PlantShop.Data
{
    public class PlantContext : IdentityDbContext<PlantUser, IdentityRole<int>,int>
    {
        public PlantContext(DbContextOptions<PlantContext> options) : base(options)
        {

        }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<PlantUser> PlantUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Plant>().ToTable("Plants");
            builder.Entity<Staff>().ToTable("Staffs");
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Specie>().ToTable("Species");
            builder.Entity<Profile>().ToTable("Profiles");
            builder.Entity<PlantUser>().ToTable("PlantUsers");
            builder.Entity<Plant>().HasKey(x => new { x.CompanyId });


        }
    }
}
