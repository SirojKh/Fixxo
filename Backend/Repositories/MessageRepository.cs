using Backend.Contexts;
using Backend.Models.Entities;
using Backend.Models.Dtos;

namespace Backend.Repositories
{
	public class MessageRepository
	{
		private readonly DataContext _context;

		public MessageRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<MessageEntity> SendMessageAsync(MessageRequest message)
		{
			_context.Messages.Add(message);
			await _context.SaveChangesAsync();
			return message;
		}

		public IEnumerable<MessageEntity> GetAllMessages()
		{
			return _context.Messages.ToList();
		}

		public async Task DeleteMessageAsync(int messageId)
		{
			var message = await _context.Messages.FindAsync(messageId);
			if (message != null)
			{
				_context.Messages.Remove(message);
				await _context.SaveChangesAsync();
			}
		}
	}
}
