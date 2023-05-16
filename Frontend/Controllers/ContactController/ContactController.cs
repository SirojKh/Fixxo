using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Frontend.Controllers.ContactController
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();

		}
		[HttpPost]
		public async Task<IActionResult> Index(ContactModel contactModel)
		{
			if (ModelState.IsValid)
			{
				using var http = new HttpClient();

				var result = await http.PostAsJsonAsync("https://localhost:7054/api/Contact/Sends", contactModel);
				if (result.IsSuccessStatusCode)
				{
					ModelState.Clear();
					return RedirectToAction(nameof(Index));
				}

				return BadRequest(result);
			}

			return View(contactModel);
		}

	}
}
