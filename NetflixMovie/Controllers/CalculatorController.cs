using Microsoft.AspNetCore.Mvc;

namespace NetflixMovie.Controllers
{
    public class CalculatorController : Controller
    {
        [ActionName("cong")]
        public int Sum(int a = 0, int b = 0)
        {
            return a + b;
        }
        public int Sub(int a = 0, int b = 0)
        {
            return a - b;
        }
        public double Mul(double a = 0, double b = 0)
        {
            return a * b;
        }
        public double Div(double a = 0, double b = 0)
        {
            return a / b;
        }
    }
}
