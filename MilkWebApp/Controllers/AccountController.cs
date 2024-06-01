using Microsoft.AspNetCore.Mvc;
using MilkData.Models;
using Newtonsoft.Json;

namespace MilkWebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly string apiUrl = "https://localhost:7120/api/v1/accounts";

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<List<Account>> GetAccountList()
		{
			try
			{
				var result = new List<Account>();
				using(var httpClient = new HttpClient())
				{
					using (var response = await httpClient.GetAsync(apiUrl))
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

		[HttpGet]
		public IActionResult Add()
		{
			return PartialView("Add");
		}
	}
}
