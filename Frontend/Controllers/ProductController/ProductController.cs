using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Frontend.Controllers.ProductController
{
	public class ProductController : Controller
	{
		public async Task<IActionResult> Index()
		{

			using var client = new HttpClient();
			var result = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7054/Api/Product");

			return View(result);

		}
		public async Task<IActionResult> Details(int productId)
		{
			using var client = new HttpClient();
			var url = $"https://localhost:7091/Api/Product/{productId}";
			var result = await client.GetFromJsonAsync<ProductModel>(url);
			return View(result);
		}

	}
}
