using ArtPlatform.Interfaces;
using ArtPlatform.Models;
using ArtPlatform.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ArtPlatform.Controllers
{
	public class TalentController : Controller
	{
        private readonly ITalentRepository _talentRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public TalentController(ITalentRepository talentRepository, ICategoryRepository categoryRepository, IMapper mapper)
		{
            this._talentRepository = talentRepository;
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

		[HttpGet]
        public IActionResult DisplayTalents(string selectedCategory = null, int page = 1, int pageSize = 6)
        {
            List<Talent> talents = _talentRepository.GetAll();
            // Filter by category if provided
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                talents = _talentRepository.GetTalentsOfCategory(selectedCategory);
            }
            var maptalents = _mapper.Map<List<TalentVM>>(talents);

            // Pagination logic
            var paginatedTalents = maptalents.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalItems = maptalents.Count;

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            ViewBag.Categories = new SelectList(_categoryRepository.GetAll().Distinct().Select(c => c.Name)); // Send categories to the view
            ViewBag.SelectedCategory = selectedCategory; // Maintain the filter in the view

            return View("DisplayTalents", paginatedTalents);
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
