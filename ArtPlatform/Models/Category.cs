using System.ComponentModel.DataAnnotations;

namespace ArtPlatform.Models
{
	public class Category
	{
		public int Id { get; set; }
		// add custom validation UNIQUE
		public required string Name { get; set; }
		[MinLength(3)]
		[MaxLength(100)]
		public required string Description { get; set; }
		public ICollection<Talent>? Talents { get; set; }
	}
}