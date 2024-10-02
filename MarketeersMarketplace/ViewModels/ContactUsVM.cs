using System.ComponentModel.DataAnnotations;

namespace MarketeersMarketplace.ViewModels
{
    public class ContactUsVM
    {
        [MinLength(2)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(2)]
        public string Message { get; set; }
    }
}
