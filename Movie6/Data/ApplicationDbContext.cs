using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie6.Models;

namespace Movie6.Data
{
    public class ApplicationDbContext : IdentityDbContext<MovieUser,IdentityRole<int>,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Profile>? Profile { get; set; }
    }
}