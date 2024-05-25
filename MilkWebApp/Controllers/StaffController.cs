using Microsoft.AspNetCore.Mvc;

namespace MilkWebApp.Controllers
{
	public class StaffController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Dashboard()
		{
			return View();
		}
		public IActionResult Product()
		{
			return View();
		}
	}
}
