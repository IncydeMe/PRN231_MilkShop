using Microsoft.AspNetCore.Mvc;

namespace MilkWebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Browse()
        {
            return View();
        }
    }
}
