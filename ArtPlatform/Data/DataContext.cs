using ArtPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtPlatform.Data
{
	public class DataContext : DbContext
	{
		public DataContext()
		{
		}

		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Artist> Artists { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	base.OnConfiguring(optionsBuilder);
		//}
	}
}
