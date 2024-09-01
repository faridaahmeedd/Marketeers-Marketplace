using ArtPlatform.Data;
using ArtPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtPlatform.Controllers
{
	public class ArtistController : Controller
	{
		DataContext context;
        public ArtistController(DataContext context)
        {
            this.context = context;
        }
        public IActionResult DisplayArtists()
		{
			List<Artist> artists = context.Artists.ToList();
			return View("DisplayArtists", artists);
		}
	}
}
