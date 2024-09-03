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
        public DbSet<Product> Products { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Category> Categories { get; set; }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	base.OnConfiguring(optionsBuilder);
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder
				.Entity<Artist>()
				.HasOne(p => p.Brand)
				.WithOne(p => p.Artist)
				.HasForeignKey<Brand>("ArtistId");
			modelBuilder
				.Entity<Brand>()
				.HasMany(p => p.Products)
				.WithOne(p => p.Brand);
			modelBuilder
				.Entity<Category>()
				.HasMany(p => p.Brands)
				.WithOne(p => p.Category);
		}
	}
}
