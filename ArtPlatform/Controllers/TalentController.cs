using ArtPlatform.Interfaces;
using ArtPlatform.Models;
using ArtPlatform.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtPlatform.Controllers
{
	public class TalentController : Controller
	{
        private readonly ITalentRepository _talentRepository;
        private readonly IMapper _mapper;

        public TalentController(ITalentRepository talentRepository, IMapper mapper)
		{
            this._talentRepository = talentRepository;
            this._mapper = mapper;
        }

		[HttpGet]
		public IActionResult DisplayTalents()
		{
			List<Talent> talents = _talentRepository.GetAll();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine(talents.Count.ToString());
            var maptalents = _mapper.Map<List<TalentVM>>(talents);
            Console.WriteLine(maptalents.Count.ToString());
            return View("DisplayTalents", maptalents);
		}

		//[HttpGet]
		//      public IActionResult AddTalent()
		//      {
		//          return View("AddTalent");
		//      }

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> AddTalent(Talent talent)
		//{
		//          var result = await _talentRepository.AddTalent(talent);

		//	if (result)
		//	{
		//              List<Talent> talents = _talentRepository.GetAll();
		//		return View("Index", talents);
		//	}
		//	else
		//	{
		//		ModelState.AddModelError("", "Error while adding the talent. Please try again.");
		//		return View("CreateTalentAccount");
		//	}
		//}
	}
}
