using ArtPlatform.Data;
using ArtPlatform.Interfaces;
using ArtPlatform.Models;
using ArtPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ArtPlatform.Controllers
{
	public class TalentController : Controller
	{
        private readonly ITalentRepository _talentRepository;

        public TalentController(ITalentRepository talentRepository)
		{
            this._talentRepository = talentRepository;
        }

		//[HttpGet]
		//public IActionResult Index()
		//{
		//	List<Talent> talents = _talentRepository.GetAll();
		//	return View("Index", talents);
		//}

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
