using ArtPlatform.Data;
using ArtPlatform.Interfaces;
using ArtPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtPlatform.Controllers
{
	public class ProductController : Controller
	{
		IProductRepository _productRepository;
		public ProductController(IProductRepository productRepository)
		{
            _productRepository = productRepository;
		}
		public IActionResult Index()
		{
			List<Product> products = _productRepository.GetAll();
			return View("Index", products);
		}
	}
}
