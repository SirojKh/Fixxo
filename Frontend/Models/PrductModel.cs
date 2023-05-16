using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
	public class ProductModel
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; }
		public string Tag { get; set; } = null!;
	}
}