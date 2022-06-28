using Microsoft.AspNetCore.Mvc;

namespace NetflixMovie.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
