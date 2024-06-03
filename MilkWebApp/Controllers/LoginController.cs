using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MilkWebApp.Controllers;

public class LoginController : Controller
{
    private readonly string apiUrl = "https://localhost:5140/Login";

    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Register()
    {
        return View();
    }

    [HttpGet]
    public Task<IActionResult> LoginRequest(string email, string password)
    {
        if (string.IsNullOrEmpty(email))
        {
            string err = "Empty email";
        }
        if (string.IsNullOrEmpty(password))
        {
            string err = "Empty password";
        }

        return null;

        //try
        //{
        //    var result = new List<Currency>();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
        //        {
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var content = await response.Content.ReadAsStringAsync();
        //                result = JsonConvert.DeserializeObject<List<Currency>>(content);
        //            }
        //        }
        //    }
        //    return result;
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception(ex.Message);
        //}
    }
}
