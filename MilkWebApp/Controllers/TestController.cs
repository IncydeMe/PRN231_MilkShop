using Microsoft.AspNetCore.Mvc;

namespace MilkWebApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return PartialView("add");
        }
    }
}
