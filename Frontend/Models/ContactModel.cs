using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
	public class ContactModel
	{
        [Required]
        public string Message { get; set; } = null!;

        [Required(ErrorMessage = "Wrong Email format")]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
