using Microsoft.AspNetCore.Mvc;
using NetflixMovie.Data;
using NetflixMovie.Models;

namespace NetflixMovie.Controllers
{
    //[ApiController]
    //[Route("[controller]/[action]")]
    public class GenreController : Controller
    {
        private readonly NetflixMovieContext _context;

        public GenreController(NetflixMovieContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Index(string id)
        {
            List<Movie> list = new List<Movie>();
            foreach(var movie in _context.Movie)
            {
                if (movie.Genre == id)
                {
                    list.Add(movie);
                }
            }
            ViewData["listGenre"]=list;
            return View();
        }
       
    }
}
