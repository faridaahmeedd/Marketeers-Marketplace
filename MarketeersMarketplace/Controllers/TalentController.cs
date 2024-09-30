using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Countries.NET;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MarketeersMarketplace.Interfaces;
using MarketeersMarketplace.Models;
using MarketeersMarketplace.ViewModels;

namespace MarketeersMarketplace.Controllers
{
    public class TalentController : Controller
    {
        private readonly ITalentRepository _talentRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly ICountriesService _countryService;

        public TalentController(ITalentRepository talentRepository, ICategoryRepository categoryRepository, IImageRepository imageRepository, IMapper mapper)
        {
            _talentRepository = talentRepository;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;
            _mapper = mapper;
            _countryService = new CountriesService();

        }

        [HttpGet]
        public IActionResult DisplayTalents(string selectedCategory = null, string searchTerm = null, int page = 1, int pageSize = 6)
        {
            List<Talent> talents = _talentRepository.GetAll();

            // Filter by category if provided
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                talents = _talentRepository.GetTalentsOfCategory(selectedCategory);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                talents = _talentRepository.GetTalentsByName(searchTerm);
            }

            var maptalents = _mapper.Map<List<TalentCardVM>>(talents);

            // Pagination logic
            var paginatedTalents = maptalents.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalItems = maptalents.Count;

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            ViewBag.Categories = new SelectList(_categoryRepository.GetAll().Distinct().Select(c => c.Name));
            ViewBag.SelectedCategory = selectedCategory;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // Return partial view for AJAX request
                return PartialView("_TalentCards", paginatedTalents);
            }

            return View("DisplayTalents", paginatedTalents); // Return full view for normal requests
        }


        [HttpGet]
        public IActionResult CreateProfile()
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll().Distinct().Select(c => c.Name));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateProfile(TalentProfileVM talentProfileVM)
        {
            if (ModelState.IsValid)
            {
                string id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                //Handle file uploads
                if (talentProfileVM.Pictures != null && talentProfileVM.Pictures.Count > 0)
                {
                    int fileCount = 0;

                    foreach (var file in talentProfileVM.Pictures)
                    {
                        if (file.Length > 0)
                        {
                            if (fileCount >= 10)
                            {
                                ModelState.AddModelError("", "You can only upload up to 10 pictures.");
                                return View(talentProfileVM);
                            }

                            _imageRepository.UploadImage(file, id);
                            fileCount++;
                        }
                    }
                }

                var maptalent = _mapper.Map<Talent>(talentProfileVM);
                maptalent.Category = _categoryRepository.GetCategory(talentProfileVM.SelectedCategory);
                maptalent.Id = id;

                await _talentRepository.CreateProfile(maptalent);

                return RedirectToAction("index", "Home");
            }
            return View(talentProfileVM);
        }

        [HttpGet]
        public IActionResult DisplayProfile(string id)
        {
            ViewData["Owner"] = false;
            if (id == null)
            {
                id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                ViewData["Owner"] = "true";
            }
            var talent = _talentRepository.GetTalent(id);
            if (talent != null)
            {
                var mapTalent = _mapper.Map<TalentProfileVM>(talent);
                mapTalent.Pictures = _imageRepository.GetImagesOfTalent(id);
                return View("DisplayProfile", mapTalent);
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditProfile()
        {
            string id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll().Distinct().Select(c => c.Name));
            var talent = _talentRepository.GetTalent(id);
            var mapTalent = _mapper.Map<TalentProfileVM>(talent);
            mapTalent.Pictures = _imageRepository.GetImagesOfTalent(id);
            return View("EditProfile", mapTalent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> EditProfile(TalentProfileVM talentProfileVM)
        {
            if (ModelState.IsValid)
            {
                string id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                //Handle file uploads
                if (talentProfileVM.Pictures != null && talentProfileVM.Pictures.Count > 0)
                {
                    int fileCount = 0;

                    foreach (var file in talentProfileVM.Pictures)
                    {
                        if (file.Length > 0)
                        {
                            if (fileCount >= 10)
                            {
                                ModelState.AddModelError("", "You can only upload up to 10 pictures.");
                                return View(talentProfileVM);
                            }

                            _imageRepository.UploadImage(file, id);
                            fileCount++;
                        }
                    }
                }

                var maptalent = _mapper.Map<Talent>(talentProfileVM);
                maptalent.Category = _categoryRepository.GetCategory(talentProfileVM.SelectedCategory);
                maptalent.Id = id;

                await _talentRepository.CreateProfile(maptalent);

                return RedirectToAction("DisplayProfile", "Talent");
            }
            return View(talentProfileVM);
        }

        [HttpPost]
        public IActionResult RemoveImage(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return BadRequest("Image URL is required");
            }
            var result = _imageRepository.DeleteImage(imageUrl);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting image");
            }
        }
    }
}
