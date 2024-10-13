using MarketeersMarketplace.ViewModels;

namespace MarketeersMarketplace.Interfaces
{
    public interface IEmailRepository
    {
        bool SendContactMail(ContactUsVM contactUsVM);
        bool SendVerificationMail(string email, string confirmationUrl);
    }
}
