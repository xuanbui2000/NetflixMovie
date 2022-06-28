using NetflixMovie.Data;
using NetflixMovie.Models;

namespace NetflixMovie.Services
{
   
        public interface IMenuService
        {
            List<Models.Genre> GetGernes();
            Models.Genre GetGerne(int? id);
            Boolean CreateGerne(Models.Genre gerne);
            Boolean EditGerne(Models.Genre gerne);
            Boolean DeleteGerne(int? id);
            Boolean GerneExists(int id);
        }
        public class MenuService : IMenuService
        {
            private readonly NetflixMovieContext _movieContext;
            public MenuService(NetflixMovieContext movieContext)
            {
                _movieContext = movieContext;
            }

            public bool CreateGerne(Genre gerne)
            {
                _movieContext.Genres.Add(gerne);
                _movieContext.SaveChanges();
                return true;
            }

            public bool DeleteGerne(int? id)
            {
                Genre genre = _movieContext.Genres.FirstOrDefault(g => g.Id == id);
                _movieContext.Remove(genre);
                _movieContext.SaveChanges();
                return true;
            }

            public bool EditGerne(Genre gerne)
            {
                _movieContext.Genres.Update(gerne);
                _movieContext.SaveChanges();
                return true;
            }

            public bool GerneExists(int id)
            {
                return _movieContext.Genres.Any(_movieContext => _movieContext.Id == id);
            }

            public Genre GetGerne(int? id)
            {
                return _movieContext.Genres.FirstOrDefault(x => x.Id == id);
            }

            public List<Genre> GetGernes()
            {
                return _movieContext.Genres.ToList();
            }
        }
    
}
