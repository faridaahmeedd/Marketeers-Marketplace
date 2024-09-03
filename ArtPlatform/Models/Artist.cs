using System.ComponentModel.DataAnnotations;

namespace ArtPlatform.Models
{
	public class Artist
	{
        public int Id { get; set; }
		[Display(Name = "First Name")]
		[MinLength(2)]
		public required string FName { get; set; }
		[Display(Name = "Last Name")]
		[MinLength(2)]
		public required string LName { get; set; }
		[Display(Name = "Mobile Number")]
		[Phone]
		public int MobileNumber { get; set; }
		[EmailAddress]
        public required string Email { get; set; }
		[MinLength(3)]
		[MaxLength(100)]
        public required string Description { get; set; }
		public byte[] Image {  get; set; } = new byte[0];
        public Brand? Brand { get; set; }
    }
}
