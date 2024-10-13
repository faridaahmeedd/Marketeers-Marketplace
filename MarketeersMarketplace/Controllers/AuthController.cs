using MarketeersMarketplace.Interfaces;
using MarketeersMarketplace.Models;
using MarketeersMarketplace.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NGeo.Yahoo.PlaceFinder;
using NuGet.Common;

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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterVM registerVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await authRepository.RegisterTalent(registerVM);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("CreateProfile", "Talent");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var result = await authRepository.RegisterTalent(registerVM, (user, token) =>
                {
                    return Url.Action("ConfirmEmail", "Auth", new { userId = user.Id, token = token }, Request.Scheme);
                });

                if (result.Succeeded)
                {
                    return RedirectToAction("ConfirmationNotice", new { email = registerVM.Email });
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResendConfirmationEmail(string email)
        {
            if (ModelState.IsValid)
            {
                var result = await authRepository.ResendConfirmationEmail(email, (user, token) =>
                {
                    return Url.Action("ConfirmEmail", "Auth", new { userId = user.Id, token = token }, Request.Scheme);
                });

                if (result)
                {
                    return RedirectToAction("ConfirmationNotice", new { email = email });
                }
                else
                {
                    ModelState.AddModelError("", "There was an error sending the mail. Please try again later.");
                }
            }
            return View("Register");
        }

        public IActionResult ConfirmationNotice(string email)
        {
            ViewBag.Email = email;
            return View();
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
                if (!await authRepository.CheckVerifiedEmail(loginVM.Email))
                {
                    ModelState.AddModelError("", "Please confirm your email before logging in.");
                    ViewBag.Email = loginVM.Email;
                    return View("Login");
                }

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

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("CreateProfile", "Talent");
            }
            var result = await authRepository.ConfirmMail(userId, token);
            ViewBag.IsConfirmed = result;
            return View("ConfirmEmail");
        }
    }
}
