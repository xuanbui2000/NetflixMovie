using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetflixMovie.Models;
using NetflixMovie.Services;
using static NetflixMovie.Services.MenuService;

namespace NetflixMovie.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
       
        public MenuController(IMenuService service)
        {
            _menuService = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(_menuService.GetGernes());
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var genre=_menuService.GetGerne(id);
            if(genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGenre([Bind("Id,GenreName")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _menuService.CreateGerne(genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var genre = _menuService.GetGerne(id);
            if(genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenreName")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _menuService.EditGerne(genre);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExist(genre.Id))
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

        private bool GenreExist(int id)
        {
           return _menuService.GerneExists(id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _menuService.GetGerne(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            _menuService.DeleteGerne(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
