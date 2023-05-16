using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers.HomeController
{
	public class HomeController : Controller
	{
		public async Task<IActionResult> Index()
		{
			using var client = new HttpClient();
			var result = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7054/Api/Product");

			return View(result);
		}
	}
}
