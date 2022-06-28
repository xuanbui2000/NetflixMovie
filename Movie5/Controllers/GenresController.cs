
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie5.Data;
using Movie5.Models;
using Movie5.Services;

namespace Movie5.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenresController : Controller
    {
        // GET: Genres
        static int IdGenre;
        private readonly IGenreService _Genreservice;
        public GenresController(IGenreService genreService)
        {
            _Genreservice = genreService;
        }
        public async Task<IActionResult> Index()
        {
              return View( _Genreservice.GetGenres());
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre =  _Genreservice.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
               _Genreservice.GenreCreate(genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre =_Genreservice.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _Genreservice.GenreUpdate(genre);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _Genreservice.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _Genreservice.GenreDelete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(int id)
        {
          return _Genreservice.GenreExit(id);
        }
        [HttpGet("{id}")]
        public IActionResult GenreList(int id)
        {
            List<Movie> list = _Genreservice.GetMovieByGenre(id);
            ViewData["listGenre"] = list;
            IdGenre = id;
            return View();
        } 
        public IActionResult Watch(int id)
        {
            var movie = _Genreservice.GetMovie(id);
            ViewData["genre"] = IdGenre;
            ViewData["movie"]=movie;
            return View();
        }


    }
}
