using MarketeersMarketplace.Interfaces;
using MarketeersMarketplace.Models;
using MarketeersMarketplace.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketeersMarketplace.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthRepository _authRepository)
        {
            authRepository = _authRepository;
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
                var result = await authRepository.RegisterTalent(registerVM);
                if (result.Succeeded)
                {
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> RegisterBusiness(RegisterVM registerVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await authRepository.RegisterBusiness(registerVM);
        //        if (result.Succeeded)
        //        {
        //            //Create cookie
        //            return RedirectToAction("CreateProfile", "Business");
        //        }
        //        else
        //        {
        //            foreach (var item in result.Errors)
        //            {
        //                ModelState.AddModelError("", item.Description);
        //            }
        //            return View("Register");
        //        }
        //    }
        //    return View("Register");
        //}

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
                if (await authRepository.Login(loginVM))
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Email or Password");
            }
            return View("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            authRepository.Logout();
            return RedirectToAction("Login");
        }
    }
}
