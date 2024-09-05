using ArtPlatform.Models;

namespace ArtPlatform.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetCategory(int id);
        Category GetCategory(string name);
        Task<bool> AddCategory(Category category);
    }
}