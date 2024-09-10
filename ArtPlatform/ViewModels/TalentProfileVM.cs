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
        public required String SelectedCategory { get; set; }
        public required List<IFormFile> Pictures { get; set; }
    }
}
