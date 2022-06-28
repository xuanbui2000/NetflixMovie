using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Movie5.Data;
using Movie5.Models;

namespace Movie5.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;
        private readonly IWebHostEnvironment _env;
        public MoviesController(MovieContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
  
        // GET: Movies
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString,int? pageNumber )
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["RateSortParm"] = sortOrder == "Rate" ? "rate_desc" : "Rate";

            if(searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"]=searchString;
            var movies = from s in _context.Movies
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                movies=movies.Where(x => x.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    movies = movies.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    movies = movies.OrderBy(s => s.ReleaseDate);
                    break; 
                case "date_desc":
                    movies = movies.OrderByDescending(s => s.ReleaseDate);
                    break;
                case "Price":
                    movies = movies.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    movies = movies.OrderByDescending(s => s.Price);
                    break;
                case "Rate":
                    movies = movies.OrderBy(s => s.Rating);
                    break;
                case "rate_desc":
                    movies = movies.OrderByDescending(s => s.Rating);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Title);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Movie>.CreateAsync(movies.AsNoTracking(),pageNumber??1,pageSize));
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
         .Include(x => x.Genres)
         .Include(s => s.Members)
             .ThenInclude(e => e.Persions)
         .AsNoTracking()
         .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            
            ViewBag.Genres = _context.Genres.ToList();
            GetNameMembers();
            GetNameCompanies();
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ReleaseDate,ProducerId,Price,MovieLink,Members")] Movie movie,int movieGenreID, int[] selectGenre, IFormFile uploadedfile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var allGenres = await _context.Genres.ToListAsync();
                    movie.Genres = allGenres.Where(x => selectGenre.Contains(x.Id)).ToList();
                    if (uploadedfile != null)
                    {
                        var imageName= Path.GetFileName(uploadedfile.FileName);
                        var name = Path.Combine(_env.WebRootPath + "/Imgs", imageName);
                        await uploadedfile.CopyToAsync(new FileStream(name, FileMode.Create));
                        movie.imageTitle =uploadedfile.FileName;

                    }
                    else
                    {
                        movie.imageTitle = "Play";
                    }
                    
                    //var courseToAdd = new GenreMovie {GenreId = movieGenreID };
                    //movie.GenreMovies = courseToAdd;
                    _context.Add(movie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
            "Try again, and if the problem persists " +
            "see your system adminzistrator.");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            ViewBag.Genres = _context.Genres.ToList();
            GetGenresExit(movie);
            GetNameMembers();
            GetNameCompanies();
            if (movie == null)
            {
                return NotFound();
            }
           
            return View(movie);
        }
        public void GetGenresExit(Movie movie)
        {
            List<Genre> listGenre = new List<Genre>();
            if (movie.Genres != null)
            {
               listGenre = movie.Genres.ToList();
            }
           
            foreach (var genre in _context.MovieGenres.ToList())
            {
                if (genre.MovieID == movie.Id)
                {
                    listGenre.Add(_context.Genres.FirstOrDefault(x=>x.Id==genre.GenreID));
                }
                
            }
            ViewBag.GenresExit = listGenre;
        }
        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("Id,Title,ReleaseDate,ProducerId,Price,imageTitle,MovieLink,Members")] Movie movie, int movieGenreID, int[] selectedGenres, IFormFile uploadedfile)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var allGenres = await _context.Genres.ToListAsync();
                    movie.Genres = allGenres.Where(x => selectedGenres.Contains(x.Id)).ToList();


                    //string path = uploadedfile.FileName.ToString();
                    //saveFileImg(path);
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            ViewData["ProducerId"] = new SelectList(_context.Companies, "Id", "Id", movie.ProducerId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id,bool? saveChangesError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again, and if the problem persists " +
            "see your system administrator.";
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie =await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();  
                return RedirectToAction(nameof(Index)); 
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(_context.Movies), new {id=id,saveChangesError=true});
            }
           
        }

        private bool MovieExists(int id)
        {
          return _context.Movies.Any(e => e.Id == id);
        }
        private void GetNameMembers(int? selectedPersonId = null)
        {
            var people = _context.Persons.AsNoTracking().ToList();
            ViewBag.People = new SelectList(people, "Id", "FullName", selectedPersonId);
        }
        //private void GetGenre(int? selectedGenreId = null)
        //{
        //    var genres = _context.GenreMovies.AsNoTracking().ToList();
        //    ViewBag.Genres = new SelectList(genres, "GenreId", "MovieId", selectedGenreId);
        //}
        private void GetNameCompanies(int? selectedCompanyId = null)
        {
            var company = _context.Companies.AsNoTracking().ToList();
            ViewBag.company = new SelectList(company, "Id", "Name", selectedCompanyId);
        }
        public IActionResult AddCompanies()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComp([Bind("Id,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                ViewData["valid"] = "Success";
                return RedirectToAction(nameof(Create));
            }
            else{

                ViewData["valid"] = "Fail";
                return RedirectToAction(nameof(Create));
            }
            return View(company);
        }

        
        //public void CreateGenreMovie([Bind("GenreId,MovieId")] GenreMovie genreMovie)
        //{
        //        _context.GenreMovies.Add(genreMovie);
        //        _context.SaveChanges();
           
        //}
       
    }
}
