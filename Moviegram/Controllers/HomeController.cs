using Microsoft.AspNetCore.Mvc;

namespace Moviegram.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Head"] = "Перший пробний проєкт";
            return View();
        }
    }
}