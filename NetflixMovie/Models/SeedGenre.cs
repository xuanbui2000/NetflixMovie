using Microsoft.EntityFrameworkCore;
using NetflixMovie.Data;

namespace NetflixMovie.Models
{
    public class SeedGenre
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NetflixMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<NetflixMovieContext>>()))
            {
                // Look for any movies.
              
                Dictionary<string, int> genres = new Dictionary<string, int>();

                foreach (var movie in context.Movie)
                {
                    if (genres.ContainsKey(movie.Genre))
                    {
                        genres[movie.Genre]++;
                    }
                    else
                    {
                        genres.Add(movie.Genre, 1);
                    }
                    
                }
               foreach(var genre in genres)
                {
                    context.Genres.Add(new Genre
                    {
                        GenreName = genre.Key.ToString(),
                        Amount= genre.Value,

                    });
                }
                context.SaveChanges();
            }
        }
    }
}
