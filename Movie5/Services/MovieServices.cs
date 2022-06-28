using Movie5.Models;

namespace Movie5.Services
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
    public class MovieServices
    {
    }
}
