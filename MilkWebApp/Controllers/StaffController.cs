using Microsoft.AspNetCore.Mvc;

namespace MilkWebApp.Controllers
{
	public class StaffController : Controller
	{
		public IActionResult Dashboard()
		{
			return View();
		}
	}
}
