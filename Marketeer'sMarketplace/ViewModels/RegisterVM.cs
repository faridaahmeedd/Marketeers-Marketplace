using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtPlatform.ViewModels
{
    public class RegisterVM
    {
        [EmailAddress]
        public required string Email { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public required string ConfirmPassword { get; set; }
    }
}
