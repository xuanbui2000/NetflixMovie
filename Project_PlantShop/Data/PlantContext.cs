using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_PlantShop.Models;

namespace Project_PlantShop.Data
{
    public class PlantContext : IdentityDbContext<PlantUser, IdentityRole<int>, int>
    {
        public PlantContext(DbContextOptions<PlantContext> options) : base(options)
        {

        }
       
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<PlantUser> PlantUsers { get; set; }
        public DbSet<Order>Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Plant>().ToTable("Plants");
            builder.Entity<Staff>().ToTable("Staffs");
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Specie>().ToTable("Species");
            builder.Entity<Profile>().ToTable("Profile");
            builder.Entity<PlantUser>().ToTable("PlantUsers");
            builder.Entity<PlantUser>()
            .HasOne(a => a.Profile)
            .WithOne(a => a.PlantUser)
            .HasForeignKey<Profile>(c => c.UserId);
            builder.Entity<Order>().ToTable("Orders");

        }
        public List<Specie> GetSpecies()
        {
            return Species.ToList();
        }
        public List<PlantUser> GetPlantUser()
        {
            return PlantUsers.AsNoTracking().ToList();
        }
    }
}
