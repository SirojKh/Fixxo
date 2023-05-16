using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Contexts
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<MessageEntity> Messages { get; set; }

	}
}
