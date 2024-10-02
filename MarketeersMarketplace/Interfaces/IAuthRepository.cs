using MarketeersMarketplace.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace MarketeersMarketplace.Interfaces
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterTalent(RegisterVM registerVM);
        Task<IdentityResult> RegisterBusiness(RegisterVM registerVM);
        Task<bool> Login (LoginVM loginVM);
        void Logout();
    }
}
