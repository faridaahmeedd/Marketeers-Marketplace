using ArtPlatform.Data;
using ArtPlatform.Interfaces;
using ArtPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtPlatform.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext context;
        public ProductRepository(DataContext context)
        {
            this.context = context;
        }
        public List<Product> GetAll() {
            return context.Products.Include(p => p.Brand).ToList();
        }
        public Product GetProduct(int id)
        {
            return context.Products.Where(p => p.Id == id).Include(p => p.Brand).FirstOrDefault();
        }

        public Product GetProductOfBrand(int id)
        {
            return context.Products.Where(p => p.Brand.Id == id).Include(p => p.Brand).FirstOrDefault();
        }
    }
}
