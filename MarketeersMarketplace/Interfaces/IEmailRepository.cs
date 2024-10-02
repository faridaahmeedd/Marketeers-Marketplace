using MarketeersMarketplace.ViewModels;

namespace MarketeersMarketplace.Interfaces
{
    public interface IEmailRepository
    {
        bool SendMail(ContactUsVM contactUsVM);
    }
}
