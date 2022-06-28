using Microsoft.EntityFrameworkCore;
using Movie5.Models;

namespace Movie5.Data
{
    public class SeedData
    {
        public static void Initialize(MovieContext context)
        {
            context.Database.EnsureCreated();


            // Look for any students.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }
            var companies = new Company[]
          {
               new  Company{ Name = "Universal Pictures", Id = "UNPIC"},
               new  Company{ Name = "Warner Bros.", Id = "WARBR"},
               new  Company{ Name = "Columbia Pictures", Id = "COLPIC"},
               new  Company{ Name = "Walt Disney Pictures", Id = "WADIPIC"},
               new  Company{ Name = "Marvel Studios", Id = "MARSTU"},
               new  Company{ Name = "Matsushiba", Id = "MATSHI"}
          };
            var genres = new Genre[]
            {
                new Genre { Name = "Action"},
                new Genre { Name = "Cartoon"},
                new Genre { Name = "Horror"},
                new Genre { Name = "Comedy"},
                new Genre { Name = "Romatic"}
            };


            foreach (Genre i in genres)
            {
                context.Genres.Add(i);
            }
            context.SaveChanges();

            foreach (Company d in companies)
            {
                context.Companies.Add(d);
            }


            context.SaveChanges();
            var movies = new Movie[]
             {
                 new Movie
                     {
                         Title = "Mamma Mia!",
                         ReleaseDate = DateTime.Parse("2008-6-30"),
                         Price = 7.99M,
                         imageTitle = "Mamma_mia.png",
                         ProducerId=companies.Single(i => i.Name=="Walt Disney Pictures").Id,
                         MovieLink="https://www.youtube.com/watch?v=8RBNHdG35WY",
                         Rating=Rating.Five

                     },
                     new Movie
                     {
                         Title = "The Tourist",
                         ReleaseDate = DateTime.Parse("2010-9-16"),
                         Price = 8.99M,
                         imageTitle = "The_Tourist.png",
                         ProducerId=companies.Single(i => i.Name=="Warner Bros.").Id,
                         MovieLink="https://www.youtube.com/watch?v=5XtbLezJtMg",
                         Rating=Rating.Four
                      },
                     new Movie
                     {
                         Title = "Now You See Me",
                         ReleaseDate = DateTime.Parse("2013-2-23"),
                         Price = 9.99M,
                         imageTitle = "Now_you_see_me.png",
                         ProducerId=companies.Single(i => i.Name=="Marvel Studios").Id,
                         MovieLink="https://www.youtube.com/watch?v=KzJNYYkkhzc",
                         Rating=Rating.Three
                     },
                      new Movie
                      {
                       Title = "The Batman",
                       ReleaseDate = DateTime.Parse("2022-1-15"),
                       Price = 3.99M,
                       imageTitle = "The_batman.png",
                       ProducerId=companies.Single(i => i.Name=="Warner Bros.").Id,
                         MovieLink="https://www.youtube.com/watch?v=mqqft2x_Aa4",
                         Rating=Rating.Four

            },
            new Movie
            {
                Title = "The Twilight Saga",
                ReleaseDate = DateTime.Parse("2008-4-15"),
                Price = 3.99M,
                imageTitle = "The_twilight_gasa.png",
                                     ProducerId=companies.Single(i => i.Name=="Walt Disney Pictures").Id,
                         MovieLink="https://www.youtube.com/watch?v=uxjNDE2fMjIY",
                         Rating=Rating.Three

            },
            new Movie
            {
                Title = "Rush Hour",
                ReleaseDate = DateTime.Parse("1998-5-25"),
                Price = 3.99M,
                imageTitle = "Rush_hour.png",
                                     ProducerId=companies.Single(i => i.Name=="Marvel Studios").Id,
                         MovieLink="https://www.youtube.com/watch?v=JMiFsFQcFLE",
                         Rating=Rating.Two

            },
            new Movie
            {
                Title = "House Of Flying Danggers",
                ReleaseDate = DateTime.Parse("2004-10-20"),
                Price = 3.99M,
                imageTitle = "House_of_flying_danggers.png",
                                     ProducerId=companies.Single(i => i.Name=="Universal Pictures").Id,
                         MovieLink="https://www.youtube.com/watch?v=-GLVaSYzAvg",
                         Rating=Rating.Five

            },
           new Movie {
                Title = "Love, Roses",
                ReleaseDate = DateTime.Parse("2014-8-10"),
                Price = 3.99M,
                imageTitle = "Love_rose.png",
                                     ProducerId=companies.Single(i => i.Name=="Universal Pictures").Id,
                         MovieLink="https://www.youtube.com/watch?v=5zL3YJKygd4",
                         Rating=Rating.Two

            },
           new Movie {
                Title = "Atonement",
                ReleaseDate = DateTime.Parse("2007-9-16"),
                Price = 3.99M,
                imageTitle = "Atonement.png",
                                     ProducerId = companies.Single(i => i.Name == "Columbia Pictures").Id,
                         MovieLink="https://www.youtube.com/watch?v=zRlkHu-R7yI",
                         Rating=Rating.Five

            },
            new Movie {
                Title = "Doraemon",
                ReleaseDate = DateTime.Parse("2007-9-16"),
                Price = 3.99M,
                imageTitle = "Doraemon.png",
                                     ProducerId = companies.Single(i => i.Name == "Matsushiba").Id,
                         MovieLink="https://www.youtube.com/watch?v=dd_R1GQwKlY",
                         Rating=Rating.Four

            }

     };


            foreach (Movie s in movies)
            {
                context.Movies.Add(s);
            }
            context.SaveChanges();
           

            var persions = new Person[]
            {
                new Person { FirstMidName ="Meryl", LastName="Streep",Dob=DateTime.Parse("1949-6-22") },
                new Person {FirstMidName ="Tom", LastName="Holland",Dob=DateTime.Parse("1996-6-1") },
                new Person {FirstMidName ="Morgan", LastName="Freeman",Dob=DateTime.Parse("1937-6-1") },
                new Person {FirstMidName ="Angelina", LastName="Jolie",Dob=DateTime.Parse("1975-6-4") },
                new Person {FirstMidName ="Robert", LastName="Pattinson",Dob=DateTime.Parse("1986-5-13") },
                new Person {FirstMidName ="Kristen", LastName="Stewart",Dob=DateTime.Parse("1990-4-8") },
                new Person {FirstMidName ="Jackie", LastName="Chan",Dob=DateTime.Parse("1954-4-7") },
                new Person {FirstMidName ="James", LastName="McAvoy",Dob=DateTime.Parse("1979-4-21") },
                new Person {FirstMidName ="Lily", LastName="Collins",Dob=DateTime.Parse("1989-3-18") },
                new Person {FirstMidName ="Ziyi", LastName="Zhang",Dob=DateTime.Parse("1979-2-9") },
                new Person {FirstMidName ="Phyllida", LastName="Lloyd",Dob=DateTime.Parse("1957-6-17") },
                new Person {FirstMidName ="Christian", LastName="Ditter",Dob=DateTime.Parse("1977-2-10") },
                new Person {FirstMidName ="Ian", LastName="McEwan",Dob=DateTime.Parse("1948-6-24") },
                new Person {FirstMidName ="Melissa", LastName="Rosenberg",Dob=DateTime.Parse("1986-8-28")},
                new Person {FirstMidName ="Fujio", LastName="Akatsuka",Dob=DateTime.Parse("1935-9-14")}
            };

            foreach (Person c in persions)
            {
                context.Persons.Add(c);
            }
            context.SaveChanges();



            var members = new Member[]
            {
                new Member {
                    PersonId = persions.Single(s => s.LastName == "Jolie").Id,
                    MovieId = movies.Single(c => c.Title == "The Tourist" ).Id,
                    Role = Role.Actor
                },
                      new Member {
                    PersonId = persions.Single(s => s.LastName == "Rosenberg").Id,
                    MovieId = movies.Single(c => c.Title == "The Twilight Saga" ).Id,
                    Role = Role.Editor
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "Pattinson").Id,
                    MovieId = movies.Single(c => c.Title == "The Twilight Saga" ).Id,
                    Role = Role.Editor
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "Stewart").Id,
                    MovieId = movies.Single(c => c.Title == "The Twilight Saga" ).Id,
                    Role = Role.Editor
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "Pattinson").Id,
                    MovieId = movies.Single(c => c.Title == "The Batman" ).Id,
                    Role = Role.Actor
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "Collins").Id,
                    MovieId = movies.Single(c => c.Title == "Love, Roses" ).Id,
                    Role = Role.Actor
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "Ditter").Id,
                    MovieId = movies.Single(c => c.Title == "Love, Roses" ).Id,
                    Role = Role.Director
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "Akatsuka").Id,
                    MovieId = movies.Single(c => c.Title == "Doraemon" ).Id,
                    Role = Role.Editor
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "Streep").Id,
                    MovieId = movies.Single(c => c.Title == "Mamma Mia!" ).Id,
                    Role = Role.Actor
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "Freeman").Id,
                    MovieId = movies.Single(c => c.Title == "Now You See Me" ).Id,
                    Role = Role.Exra
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "Zhang").Id,
                    MovieId = movies.Single(c => c.Title == "House Of Flying Danggers" ).Id,
                    Role = Role.Actor
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "McEwan").Id,
                    MovieId = movies.Single(c => c.Title == "Atonement" ).Id,
                    Role = Role.Editor
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "McAvoy").Id,
                    MovieId = movies.Single(c => c.Title == "Atonement" ).Id,
                    Role = Role.Actor
                },  new Member {
                    PersonId = persions.Single(s => s.LastName == "Chan").Id,
                    MovieId = movies.Single(c => c.Title == "Rush Hour" ).Id,
                    Role = Role.Exra
                },
            };

            foreach (Member e in members)
            {
                context.Members.Add(e);
            }
            context.SaveChanges();
            var movieGenre = new MovieGenre[]{
                new MovieGenre
                {
                    GenreID=genres.Single(c => c.Name == "Cartoon" ).Id,
                    MovieID=movies.Single(c => c.Title == "Doraemon" ).Id,
                },
                 new MovieGenre
                {
                    GenreID=genres.Single(c => c.Name == "Romatic" ).Id,
                    MovieID=movies.Single(c => c.Title == "Mamma Mia!" ).Id,
                },
                 new MovieGenre
                {
                    GenreID=genres.Single(c => c.Name == "Horror" ).Id,
                    MovieID=movies.Single(c => c.Title == "Love, Roses" ).Id,
                },
                  new MovieGenre
                {
                    GenreID=genres.Single(c => c.Name == "Comedy" ).Id,
                    MovieID=movies.Single(c => c.Title == "House Of Flying Danggers" ).Id,
                },

                new MovieGenre
                {
                    GenreID=genres.Single(c => c.Name == "Action" ).Id,
                    MovieID=movies.Single(c => c.Title == "The Tourist" ).Id,
                },
                   new MovieGenre
                {
                    GenreID=genres.Single(c => c.Name == "Comedy" ).Id,
                    MovieID=movies.Single(c => c.Title == "Atonement" ).Id,
                },


                new MovieGenre
                {
                    GenreID=genres.Single(c => c.Name == "Romatic" ).Id,
                    MovieID=movies.Single(c => c.Title == "Love, Roses" ).Id,
                },

                new MovieGenre
                {
                    GenreID=genres.Single(c => c.Name == "Horror" ).Id,
                    MovieID=movies.Single(c => c.Title == "Now You See Me" ).Id,
                },

            };
            foreach (MovieGenre genre in movieGenre)
            {
                context.MovieGenres.Add(genre);
            }
            context.SaveChanges();

        }
    }

}
