using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_PlantShop.Data;
using Project_PlantShop.Models;
using System.Diagnostics;

namespace Project_PlantShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<PlantUser> _signInManager;
        private readonly PlantContext _context;
        private readonly IWebHostEnvironment _host;



        public HomeController(SignInManager<PlantUser> signInManager, PlantContext context, IWebHostEnvironment host)
        {
           
            _signInManager = signInManager;
            _context = context;
            _host = host;
        }
       
        
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewBag.Staff = _context.Staffs.AsNoTracking().ToList();
            List<Specie>listSpecies= _context.Species.ToList();
            ViewBag.Categories = listSpecies;
            var plantContext = _context.Plants.Include(p => p.Species);
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["RateSortParm"] = sortOrder == "Rate" ? "rate_desc" : "Rate";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var plant = from s in _context.Plants
                        select s;
           
            if (!String.IsNullOrEmpty(searchString))
            {
                plant = plant.Where(x => x.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    plant = plant.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    plant = plant.OrderBy(s => s.Dob);
                    break;
                case "date_desc":
                    plant = plant.OrderByDescending(s => s.Dob);
                    break;
                case "Price":
                    plant = plant.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    plant = plant.OrderByDescending(s => s.Price);
                    break;
                case "Rate":
                    plant = plant.OrderBy(s => s.Rating);
                    break;
                case "rate_desc":
                    plant = plant.OrderByDescending(s => s.Rating);
                    break;
                default:
                    plant = plant.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Plant>.CreateAsync(plant.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
       
        public async Task<IActionResult> Specie(int id, string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewBag.NameSpecie = _context.Species.FirstOrDefault(x => x.Id == id).Name;   
            var plantContext = _context.Plants.Include(p => p.Species);
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["RateSortParm"] = sortOrder == "Rate" ? "rate_desc" : "Rate";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var plant = from s in _context.Plants where s.SpecieId== id
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                plant = plant.Where(x => x.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    plant = plant.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    plant = plant.OrderBy(s => s.Dob);
                    break;
                case "date_desc":
                    plant = plant.OrderByDescending(s => s.Dob);
                    break;
                case "Price":
                    plant = plant.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    plant = plant.OrderByDescending(s => s.Price);
                    break;
                case "Rate":
                    plant = plant.OrderBy(s => s.Rating);
                    break;
                case "rate_desc":
                    plant = plant.OrderByDescending(s => s.Rating);
                    break;
                default:
                    plant = plant.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Plant>.CreateAsync(plant.AsNoTracking(), pageNumber ?? 1, pageSize)); 
        }
        
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants
                .Include(p => p.Species)
                .Include(p => p.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
        public async Task<IActionResult> AddToCard(int product, int quantities)
        {
            
            Plant plant = _context.Plants.FirstOrDefault(s => s.Id == product);
            if (quantities > plant.Quantity)
            {
                ModelState.AddModelError(string.Empty, "There are: "+plant.Quantity+" plant");
                return View();
            }
            else
            {
                return View();
            }

        }
        //public void AddToOrder(Plant plant,int quantity)
        //{
        //    string currentUserId = User.Identity.GetUserId();
        //    ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

        //    Order order =new Order
        //     {
        //         ProductId=plant.Id,
        //         UserId=user.Id,
        //         quantity=quantity,

        //     };
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}