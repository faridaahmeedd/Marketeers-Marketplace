using MarketeersMarketplace.Models;
using System.ComponentModel.DataAnnotations;

namespace MarketeersMarketplace.ViewModels
{
    public class TalentCardVM
    {
        public string Id { get; set; }
        [MinLength(2)]
        public required string Name { get; set; }
        [MinLength(3)]
        [MaxLength(100)]
        public required string Bio { get; set; }
        //public required IFormFile Image { get; set; }
        public required string CategoryName { get; set; }
        public required string ImagePath { get; set; }

        //[RegularExpression(@"^[a-zA-Z\s]{3,20}$", ErrorMessage = "Name must contain only letters and be between 3 and 20 characters long.")]
        //public required string Name { get; set; }
        //[RegularExpression(@"^[a-zA-Z0-9\s]{3,100}$", ErrorMessage = "The field Bio must be between 3 and 100 characters and can contain only letters, numbers, and spaces.")]
        //public required string Bio { get; set; }
    }
}
