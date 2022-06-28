using Microsoft.EntityFrameworkCore;
using NetflixMovie.Data;

namespace NetflixMovie.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NetflixMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<NetflixMovieContext>>()))
            {
                // Look for any movies.
                //if (context.Movie.Any())
                //{
                //    return;   // DB has been seeded
                //}

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Through my window",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        imageTitle="img1"
                    },

                    new Movie
                    {
                        Title = "Red Notice",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                         imageTitle = "img2"
                    },

                    new Movie
                    {
                        Title = "Ava",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        imageTitle = "img3"
                    },

                    new Movie
                    {
                        Title = "Spirited away",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        imageTitle = "img4"
                    },

                    new Movie
                    {
                        Title = "The old guard",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        imageTitle = "img5"
                    },
                    new Movie
                    {
                        Title = "Transformers",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        imageTitle = "img6"
                    },
                    new Movie
                    {
                        Title = "Doraemon",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        imageTitle = "img7"
                    },
                    new Movie
                    {
                        Title = "Joker",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        imageTitle = "img8"
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
