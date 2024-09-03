using System.ComponentModel.DataAnnotations;

namespace ArtPlatform.Models
{
	public class Product
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		[RegularExpression("[a-zA-Z]{3, 100}")]
		public required string Description { get; set; }
		public required float Price { get; set; }
		[Display(Name= "Height in cm")]
		public required float Height { get; set; }
		[Display(Name = "Width in cm")]
		public required float Width { get; set; }
		public byte[] Image { get; set; } = new byte[0];
		public required Brand Brand { get; set; }
    }
}
