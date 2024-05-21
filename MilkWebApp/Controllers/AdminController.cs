using Microsoft.AspNetCore.Mvc;

namespace MilkWebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
