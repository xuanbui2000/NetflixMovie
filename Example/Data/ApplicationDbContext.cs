using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlantsShop.Models;

namespace Example.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Company>Companies { get; set; }
        public DbSet<Specie>Species { get; set; }
        public DbSet<Acount>Acounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Staff>().ToTable("Staffs");
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Specie>().ToTable("Species");
            builder.Entity<Acount>().ToTable("Acounts");
            builder.Entity<Order>().HasKey(x => new {x.ProductId,x.UserId});
            builder.Entity<Product>().HasKey(x => new {x.SpecieId,x.CompanyId});

        }

    }
}