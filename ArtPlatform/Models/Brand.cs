namespace ArtPlatform.Models
{
	public class Brand
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; }
        public Uri? InstagramUrl { get; set; }
		public Uri? TiktokUrl { get; set; }
		public Uri? FacebookUrl { get; set; }
		public byte[] Logo { get; set; } = new byte[0];
		public required Artist Artist { get; set; }
		public required Category Category { get; set; } 
		public ICollection<Product>? Products { get; set; }
	}
}
