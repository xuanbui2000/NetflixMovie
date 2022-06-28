using Microsoft.EntityFrameworkCore;
using Movie5.Data;
using Movie5.Models;

namespace Movie5.Services
{
    public interface IGenreService
    {
        List<Models.Genre> GetGenres();
        List<Models.Movie> GetMovieByGenre(int id);
        Models.Genre GetGenre(int? id);
        Boolean GenreCreate(Models.Genre genre);
        Boolean GenreUpdate(Models.Genre genre);
        Boolean GenreDelete(int id);
        Boolean GenreExit(int id);
        Models.Movie GetMovie(int id);
    }
    public class GenreServices : IGenreService
    {
        private readonly MovieContext _context;
        public GenreServices(MovieContext context)
        {
            _context = context;
        }

        public bool GenreCreate(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return true;
        }

        public bool GenreDelete(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(x => x.Id == id);
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return true;
        }

        public bool GenreExit(int id)
        {
            return _context.Genres.Any(x => x.Id == id);
        }



        public bool GenreUpdate(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
            return true;
        }

        public Genre GetGenre(int? id)
        {
            return _context.Genres.FirstOrDefault(x => x.Id == id);
        }

        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> GetMovieByGenre(int id)
        {
            var ListGenre=_context.MovieGenres.ToList();
            List<Movie> listMo = new List<Movie>();

            listMo = _context.Movies.Where(x => x.Genres.Any(g => g.Id == id)).ToList();
            if (listMo.Count>1)
            {
                return listMo;
            }
            foreach (var gen in ListGenre)
            {
                if (gen.GenreID == id)
                {
                    listMo.Add(_context.Movies.FirstOrDefault(x => x.Id == gen.MovieID));
                }
            }
            return listMo;
        }
    }
}
