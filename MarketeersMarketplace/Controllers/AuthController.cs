using MarketeersMarketplace.Models;
using MarketeersMarketplace.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketeersMarketplace.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                Talent user = new Talent();
                user.Email = registerVM.Email;
                user.UserName = registerVM.Email;
                user.PasswordHash = registerVM.Password;
                var result = await userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    //Create cookie
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("CreateProfile", "Talent");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View("Register");
                }
            }
            return View("Register");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    if (await userManager.CheckPasswordAsync(user, loginVM.Password))
                    {
                        await signInManager.SignInAsync(user, loginVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid Email or Password");
            }
            return View("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            //Delete Cookie
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
