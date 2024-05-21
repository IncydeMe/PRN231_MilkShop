using Microsoft.AspNetCore.Mvc;

namespace MilkWebApp.Controllers;

public class LoginController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Register()
    {
        return View();
    }
}
