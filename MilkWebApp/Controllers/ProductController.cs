using Microsoft.AspNetCore.Mvc;

namespace MilkWebApp.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
