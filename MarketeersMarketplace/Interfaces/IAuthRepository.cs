using MarketeersMarketplace.Models;
using MarketeersMarketplace.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace MarketeersMarketplace.Interfaces
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterTalent(RegisterVM registerVM, Func<AppUser, string, string> generateEmailConfirmationUrl);
        Task<bool> ResendConfirmationEmail(string email, Func<AppUser, string, string> generateEmailConfirmationUrl);
        Task<IdentityResult> RegisterBusiness(RegisterVM registerVM);
        Task<bool> Login (LoginVM loginVM);
        void Logout();
        Task<bool> ConfirmMail(string userId, string token);
        Task<bool> CheckVerifiedEmail(string email);
    }
}
