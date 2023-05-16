using Backend.Models.Entities;

namespace Backend.Models.Dtos
{
	public class ProductRequest
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; }
		public int StarRating { get; set; }
		public string Tag { get; set; } = null!;


		public static implicit operator ProductEntity(ProductRequest req)
		{
			return new ProductEntity
			{
				Name = req.Name,
				Description = req.Description,
				Price = req.Price,
				ImageUrl = req.ImageUrl,
				StarRating = req.StarRating,
				Tag = req.Tag
			};
		}
	}
}
