using MarketeersMarketplace.Models;
using AutoMapper;
using MarketeersMarketplace.Interfaces;
using MarketeersMarketplace.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketeersMarketplace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITalentRepository talentRepository;
        private readonly IEmailRepository emailRepository;
        private readonly IMapper mapper;

        public HomeController(ITalentRepository talentRepository, IEmailRepository emailRepository, IMapper mapper)
        {
            this.talentRepository = talentRepository;
            this.emailRepository = emailRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Talent> talents = talentRepository.GetAll();
            var maptalents = mapper.Map<List<TalentCardVM>>(talents);
            return View("Index", maptalents);
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SendMessage(ContactUsVM contactUsVM)
        {
            bool emailSent = emailRepository.SendContactMail(contactUsVM);

            if (emailSent)
            {
                return RedirectToAction("MessageSent");
            }
            else
            {
                ModelState.AddModelError("", "There was an error sending the message. Please try again later.");
            }
            return PartialView("_ContactFormPartial", contactUsVM);
        }

        public IActionResult MessageSent()
        {
            return View();
        }

    }
}
