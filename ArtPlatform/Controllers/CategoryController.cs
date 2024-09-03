using Microsoft.AspNetCore.Mvc;

namespace ArtPlatform.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
