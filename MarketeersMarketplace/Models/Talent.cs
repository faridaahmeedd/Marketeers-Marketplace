using System.ComponentModel.DataAnnotations;

namespace MarketeersMarketplace.Models
{
    public class Talent : AppUser
    {
        [Display(Name = "First Name")]
        [MinLength(2)]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        [MinLength(2)]
        public string LName { get; set; }
        [MinLength(2)]
        public string Country { get; set; }
        [MinLength(2)]
        public string City { get; set; }
        [Display(Name = "Mobile Number")]
        public int MobileNumber { get; set; }
        public Uri? InstagramUrl { get; set; }
        public Uri? TiktokUrl { get; set; }
        public Uri? FacebookUrl { get; set; }
        [MinLength(3)]
        [MaxLength(600)]
        public string Bio { get; set; }
        public ICollection<Image>? Images { get; set; }
        public Category? Category { get; set; }
    }
}
