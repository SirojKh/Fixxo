using Microsoft.AspNetCore.Mvc;
using Backend.Repositories;
using Backend.Models.Dtos;
using Backend.Filters;

namespace Backend.Controllers
{
	//[ApiKey]
	[Route("api/")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly MessageRepository _repository;

		public MessageController(MessageRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IActionResult GetAllMessages()
		{
			var messages = _repository.GetAllMessages();
			return Ok(messages);
		}

		[HttpPost]
		[Route("Contact/Send")]
		public async Task<IActionResult> SendMessage(MessageRequest message)
		{
			if (ModelState.IsValid)
			{
				if (message != null)
				{
					await _repository.SendMessageAsync(message);
					return Created("", null);
				}
			}
			return BadRequest();
		}


		[HttpDelete("{messageId}")]
		public async Task<IActionResult> DeleteMessage(int messageId)
		{
			await _repository.DeleteMessageAsync(messageId);

			return NoContent();
		}
	}
}
