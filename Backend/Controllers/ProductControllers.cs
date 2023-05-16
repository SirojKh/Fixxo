using Microsoft.AspNetCore.Mvc;
using Backend.Repositories;
using Backend.Models.Dtos;
using Backend.Filters;

namespace Backend.Controllers
{
	//ApiKey]
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		#region Constrctors
		private readonly ProductRepository _repository;

		public ProductController(ProductRepository repository)
		{
			_repository = repository;
		}
		
		#endregion

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _repository.GetAllAsync());
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductRequest req)
		{
			if (ModelState.IsValid)
			{
				var product = await _repository.CreateAsync(req);
				if (product != null)
				{
					return Created("", product);
				}
			}
			return BadRequest();
		}

		[HttpGet("tag/{tagName}")]
		public async Task<IActionResult> GetByTag(string tagName)
		{
			var products = await _repository.GetByTagAsync(tagName);
			if (products != null && products.Any())
				return Ok(products);
			return NotFound();
		}

		[HttpGet("details/{id}")]
		public async Task<ActionResult> GetProduct(int id)
		{
			var product = await _repository.GetByIdAsync(id);
			if (product != null)
				return Ok(product);
			return NotFound();
		}

		[HttpGet("search/{searchTerm}")]
		public async Task<IActionResult> Search(string searchTerm)
		{
			var product = await _repository.SearchAsync(searchTerm);
			if (product != null && product.Any())
				return Ok(product);
			return NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProductById(int id)
		{
			var product = await _repository.GetProductByIdAsync(id);

			if (product == null)
			{
				return NotFound();
			}

			await _repository.DeleteProductAsync(product);
			return NoContent();
		}
	}
}
