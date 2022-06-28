using Microsoft.AspNetCore.Mvc;
using NetflixMovie.Models;

namespace NetflixMovie.Controllers
{
    public class MathController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult Calculator()
        {
            return View("Calculator");
        }

        [HttpPost]
        public IActionResult CalculatorMethod(Expression ex)
        {
            switch (ex.Operator)
            {
                case "+":
                    ex.Value = ex.A + ex.B;
                    return View("Calculator", ex);
                case "-":
                    ex.Value = ex.A - ex.B;
                    return View("Calculator", ex);
                case "x":
                    ex.Value = ex.A * ex.B;
                    return View("Calculator", ex);
                case "/":
                    ex.Value = ex.A / ex.B;
                    return View("Calculator", ex);
            }
            return View("Calculator", ex);
        }

        [HttpPost]
        public IActionResult Sub(Expression ex)
        {
            ex.Value = ex.A - ex.B;
            return View("Calculator", ex);
        }
        [HttpPost]
        public IActionResult Mul(Expression ex)
        {
            ex.Value = ex.A * ex.B;
            return View("Calculator", ex);
        }
        [HttpPost]
        public IActionResult Div(Expression ex)
        {
            if (ex.B == 0)
            {
                ex.B = 1;
            }
            ex.Value = ex.A / ex.B;
            return View("Calculator", ex);
        }
    }
}
