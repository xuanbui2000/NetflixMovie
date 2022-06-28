using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie5.Models;

namespace Movie5.Data
{
    public class MovieContext : IdentityDbContext<MovieUser, IdentityRole<int>, int>
    
    {
        public MovieContext(DbContextOptions<MovieContext> options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Profile>().ToTable("Profile");
            modelBuilder.Entity<MovieGenre>().ToTable("MovieGenre");
            //modelBuilder.Entity<Profile>().HasKey(c => new { c.UserId});
            modelBuilder.Entity<MovieGenre>().HasKey(c => new { c.MovieID, c.GenreID });
            modelBuilder.Entity<Member>()
              .HasKey(c => new { c.MovieId, c.PersonId });

        }
    }
   
}
