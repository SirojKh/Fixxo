using Backend.Models.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities
{
	public class ProductEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = null!;

		[Required]
		public string Description { get; set; } = null!;

		[Column(TypeName = "money")]
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; }
		public int StarRating { get; set; }

		[Required]
		public string Tag { get; set; } = null!;

		public static implicit operator ProductResponse(ProductEntity entity)
		{
			return new ProductResponse
			{
				Id = entity.Id,
				Name = entity.Name,
				Description = entity.Description,
				Price = entity.Price,
				ImageUrl = entity.ImageUrl,
				StarRating = entity.StarRating,
				Tag = entity.Tag
			};
		}
	}
}
