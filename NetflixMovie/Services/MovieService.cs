using NetflixMovie.Data;
using NetflixMovie.Models;
using System.Linq;

namespace NetflixMovie.Services
{
    public interface IMovieService
    {
       Task<IList<Movie>> GetAllMovieAsync();
         Movie GetMovie(int? id);
         Boolean CreateMovide(Movie movie);
         Boolean EditMovie(Movie movie);
         Boolean DeleteMovie(int? id);
         Boolean MovieExists(int id);
    }
    public class MovieService:IMovieService
    {
        private readonly NetflixMovieContext _movieContext;
        public MovieService(NetflixMovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public bool CreateMovide(Movie movie)
        {
           _movieContext.Movie.Add(movie);
            _movieContext.SaveChanges();
            return true;
        }

        public bool DeleteMovie(int? id)
        {
            Movie movie = _movieContext.Movie.Find(id);
            _movieContext.Movie.Remove(movie);
            _movieContext.SaveChanges();
            return true;
        }

        public bool EditMovie(Movie movie)
        {
            _movieContext.Movie.Update(movie);
            _movieContext.SaveChanges();
            return true;
        }

        public async Task<IList<Movie>> GetAllMovieAsync()
        {
            return _movieContext.Movie.ToList();
        }

        public Movie GetMovie(int? id)
        {
            return _movieContext.Movie.FirstOrDefault(m => m.Id == id);
        }

        public bool MovieExists(int id)
        {
            return _movieContext.Movie.Any(Movie => Movie.Id == id);
        }

       
    }
}
