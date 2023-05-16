using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities
{
	public class MessageEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Message { get; set; } = null!;

		[Required]
		public string Email { get; set; } = null!;
	}
}
