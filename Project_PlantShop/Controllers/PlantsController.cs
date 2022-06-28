using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_PlantShop.Data;
using Project_PlantShop.Models;

namespace Project_PlantShop.Controllers
{
    //[Authorize(Roles = "Manager,Staff")]
    public class PlantsController : Controller
    {
        private readonly PlantContext _context;

        public PlantsController(PlantContext context)
        {
            _context = context;
        }

        // GET: Plants
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
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

        // GET: Plants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants
                .Include(p => p.Species)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // GET: Plants/Create
        //[Authorize(Roles = "Manager,Staff")]
        public IActionResult Create()
        {
            ViewData["SpecieId"] = new SelectList(_context.Species, "Id", "Id");
            return View();
        }

        // POST: Plants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SpecieId,Dob,Price,RealPrice,Discount,Quantity,Rating,ImgTitle,Description")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecieId"] = new SelectList(_context.Species, "Id", "Id", plant.SpecieId);
            return View(plant);
        }

        // GET: Plants/Edit/5
       // [Authorize(Roles = "Manager,Staff")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            ViewData["SpecieId"] = new SelectList(_context.Species, "Id", "Id", plant.SpecieId);
            return View(plant);
        }

        // POST: Plants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Manager,Staff")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SpecieId,Dob,Price,RealPrice,Discount,Quantity,Rating,ImgTitle,Description")] Plant plant)
        {
            if (id != plant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantExists(plant.Id))
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
            ViewData["SpecieId"] = new SelectList(_context.Species, "Id", "Id", plant.SpecieId);
            return View(plant);
        }

        // GET: Plants/Delete/5
      //  [Authorize(Roles = "Manager,Staff")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants
                .Include(p => p.Species)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // POST: Plants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "Manager,Staff")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plants == null)
            {
                return Problem("Entity set 'PlantContext.Plants'  is null.");
            }
            var plant = await _context.Plants.FindAsync(id);
            if (plant != null)
            {
                _context.Plants.Remove(plant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantExists(int id)
        {
          return _context.Plants.Any(e => e.Id == id);
        }
        public IActionResult PlantsWithSpecie(int id)
        {
            ViewBag.SpecieName = _context.Species.FirstOrDefault(x => x.Id == id);
            ViewBag.plants = _context.Plants.Where(x => x.SpecieId == id).ToList();
            return View();
        }
    }
}
