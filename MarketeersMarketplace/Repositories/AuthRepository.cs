using MarketeersMarketplace.Interfaces;
using MarketeersMarketplace.Models;
using MarketeersMarketplace.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace MarketeersMarketplace.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<bool> Login(LoginVM loginVM)
        {
            var user = await userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                if (await userManager.CheckPasswordAsync(user, loginVM.Password))
                {
                    await signInManager.SignInAsync(user, loginVM.RememberMe);
                    return true;
                }
            }
            return false;
        }

        public async void Logout()
        {
            //Delete Cookie
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterBusiness(RegisterVM registerVM)
        {
            throw new NotImplementedException();
            //Business user = new Business();
            //user.Email = registerVM.Email;
            //user.UserName = registerVM.Email;
            //user.PasswordHash = registerVM.Password;
            //var result = await userManager.CreateAsync(user, registerVM.Password);
            //if(result.Succeeded)
            //{
            //    //Create cookie
            //    await signInManager.SignInAsync(user, isPersistent: false);
            //}
            //return result;
        }

        public async Task<IdentityResult> RegisterTalent(RegisterVM registerVM)
        {
            Talent user = new Talent();
            user.Email = registerVM.Email;
            user.UserName = registerVM.Email;
            user.PasswordHash = registerVM.Password;
            var result = await userManager.CreateAsync(user, registerVM.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
            }
            return result;
        }
    }
}
