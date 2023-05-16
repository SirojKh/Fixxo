using Backend.Contexts;
using Backend.Models.Entities;
using Backend.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
	public class ProductRepository
	{
		private readonly DataContext _context;

		public ProductRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ProductResponse>> GetAllAsync()
		{
			var items = await _context.Products.ToListAsync();

			var products = new List<ProductResponse>();
			foreach (var item in items)
				products.Add(item);
			return products;

		}

		public async Task<ProductResponse> CreateAsync(ProductEntity product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return product;
		}

		public async Task<IEnumerable<ProductResponse>> GetByTagAsync(string tag)
		{
			var items = await _context.Products.Where(x => x.Tag.ToLower() == tag.ToLower()).ToListAsync();
			var products = new List<ProductResponse>();

			foreach (var item in items)
				products.Add(item);

			return products;
		}

		public async Task<ProductResponse> GetByIdAsync(int id)
		{
			var item = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

			if (item == null)
				return null;

			return item;
		}

		public async Task<IEnumerable<ProductResponse>> SearchAsync(string searchTerm)
		{
			var items = await _context.Products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) ||
														   x.Description.ToLower().Contains(searchTerm.ToLower()) ||
														   x.Tag.ToLower().Contains(searchTerm.ToLower())).ToListAsync();

			var products = new List<ProductResponse>();

			foreach (var item in items)
				products.Add(item);
			return products;
		}

		public async Task<ProductEntity> GetProductByIdAsync(int id)
		{
			return await _context.Products.FindAsync(id);
		}

		public async Task DeleteProductAsync(ProductEntity product)
		{
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
		}


	}
}
