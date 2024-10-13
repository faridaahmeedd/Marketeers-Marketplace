using Azure.Core;
using MarketeersMarketplace.Interfaces;
using MarketeersMarketplace.Models;
using MarketeersMarketplace.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Policy;

namespace MarketeersMarketplace.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IEmailRepository emailRepository;

        public AuthRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailRepository emailRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailRepository = emailRepository;
        }

        public async Task<bool> Login(LoginVM loginVM)
        {
            var user = await userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                if (!await userManager.IsEmailConfirmedAsync(user))
                {
                    return false;
                }
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

        public async Task<bool> CheckVerifiedEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if (await userManager.IsEmailConfirmedAsync(user))
                {
                    return true;
                }
            }
            return false;
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

        public async Task<IdentityResult> RegisterTalent(RegisterVM registerVM, Func<AppUser, string, string> generateEmailConfirmationUrl)
        {
            Talent user = new Talent
            {
                Email = registerVM.Email,
                UserName = registerVM.Email
            };
            var result = await userManager.CreateAsync(user, registerVM.Password);
            if (result.Succeeded)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationUrl = generateEmailConfirmationUrl(user, token);
                emailRepository.SendVerificationMail(user.Email, confirmationUrl);
            }
            return result;
        }

        public async Task<bool> ResendConfirmationEmail(string email, Func<AppUser, string, string> generateEmailConfirmationUrl)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationUrl = generateEmailConfirmationUrl(user, token);
                emailRepository.SendVerificationMail(user.Email, confirmationUrl);
                return true;
            }
            return false;
        }

        public async Task<bool> ConfirmMail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
