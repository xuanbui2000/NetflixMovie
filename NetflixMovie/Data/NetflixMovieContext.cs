using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetflixMovie.Models;

namespace NetflixMovie.Data
{
    public class NetflixMovieContext : DbContext
    {
        public NetflixMovieContext()
        {
        }

        public NetflixMovieContext (DbContextOptions<NetflixMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie>Movie { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
