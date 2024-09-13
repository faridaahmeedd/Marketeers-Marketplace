using ArtPlatform.Models;
using System.ComponentModel.DataAnnotations;

namespace ArtPlatform.ViewModels
{
    public class TalentProfileVM
    {
        [Display(Name = "First Name")]
        [MinLength(2)]
        public required string FName { get; set; }
        [Display(Name = "Last Name")]
        [MinLength(2)]
        public required string LName { get; set; }
        public required string Email { get; set; }
        [MinLength(2)]
        public required string Country { get; set; }
        [MinLength(2)]
        public required string City { get; set; }
        [Display(Name = "Mobile Number")]
        //[RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Invalid Mobile Number. Must be exactly 11 digits.")]
        public required int MobileNumber { get; set; }
        [MinLength(3)]
        [MaxLength(500)]
        public required string Bio { get; set; }
        [Display(Name = "Category")]
        public required String SelectedCategory { get; set; }
        [Display(Name = "Instagram Url")]
        [DataType(DataType.Url)]
        public required Uri InstagramUrl { get; set; }
        [Display(Name = "Tiktok Url")]
        [DataType(DataType.Url)]
        public required Uri TiktokUrl { get; set; }
        [Display(Name = "Facebook Url")]
        [DataType(DataType.Url)]
        public Uri? FacebookUrl { get; set; }
        public required List<IFormFile> Pictures { get; set; }
        public List<string>? ExistingImageUrls { get; set; }
    }
}
