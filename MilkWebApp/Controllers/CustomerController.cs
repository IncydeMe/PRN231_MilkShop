using Microsoft.AspNetCore.Mvc;
using MilkData.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MilkWebApp.Controllers;

public class CustomerController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<List<Account>> GetAll()
    {
        try
        {
            var result = new List<Account>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<Account>>(content);
                    }
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
