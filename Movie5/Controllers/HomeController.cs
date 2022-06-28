using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie5.Data;
using Movie5.Models.MovieViewModels;
using Movie5.Models;
using System.Diagnostics;

namespace Movie5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieContext _context;
        public HomeController(ILogger<HomeController> logger,MovieContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       public IActionResult HomeMenu()
        {
            return View();
        }
       public async Task<ActionResult> About()
        {

            //IQueryable<MemberDateGroup> data =
            //    from member in _context.Members
            //    group member by member.MovieId into dataGroup
            //    select new MemberDateGroup()
            //    {
            //        Id = dataGroup.Key,
            //        Title = _context.Movies.FirstOrDefault(x => x.Id == dataGroup.Key).Title,
            //        MemberCount = dataGroup.Count()

            //    };
            var movies = _context.Movies.Include(x => x.Members).ToList();
            List<MemberDateGroup> list = new List<MemberDateGroup>();
            foreach(var movie in movies)
            {
                list.Add(new MemberDateGroup()
                {
                    Title = movie.Title,
                    MemberCount = movie.Members.Count()
                });
;            }

            return View(list);
        }
    }
}