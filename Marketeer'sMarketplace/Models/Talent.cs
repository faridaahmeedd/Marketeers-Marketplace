using System.ComponentModel.DataAnnotations;

namespace ArtPlatform.Models
{
	public class Talent : AppUser
    {
		[Display(Name = "First Name")]
		[MinLength(2)]
		public required string FName { get; set; }
		[Display(Name = "Last Name")]
		[MinLength(2)]
		public required string LName { get; set; }
        [MinLength(2)]
        public required string Country { get; set; }
        [MinLength(2)]
        public required string City { get; set; }
        [Display(Name = "Mobile Number")]
		[Phone]
		public required int MobileNumber { get; set; }
		[MinLength(3)]
		[MaxLength(100)]
        public required string Bio { get; set; }
		public required ICollection<Image> Images {  get; set; }
		public required Category Category { get; set; }
    }
}
