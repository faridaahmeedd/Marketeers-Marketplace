using ArtPlatform.Models;

namespace ArtPlatform.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetProduct(int id);
        Product GetProductOfBrand(int id);
    }
}
