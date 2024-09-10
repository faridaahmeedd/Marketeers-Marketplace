using ArtPlatform.Interfaces;
using ArtPlatform.Models;
using ArtPlatform.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArtPlatform.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ITalentRepository talentRepository;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, ITalentRepository talentRepository, IMapper mapper)
		{
			_logger = logger;
            this.talentRepository = talentRepository;
            this.mapper = mapper;
        }

		[HttpGet]
		public IActionResult Index()
		{
            List<Talent> talents = talentRepository.GetAll();
            var maptalents = mapper.Map<List<TalentCardVM>>(talents);
            Console.WriteLine(maptalents.Count.ToString());
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
	}
}
