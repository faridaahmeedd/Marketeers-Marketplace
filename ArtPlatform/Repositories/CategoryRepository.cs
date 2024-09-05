using ArtPlatform.Data;
using ArtPlatform.Interfaces;
using ArtPlatform.Models;

namespace ArtPlatform.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;

        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }
        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }
        public Category GetCategory(int id)
        {
            return context.Categories.Where(p => p.Id == id).FirstOrDefault();
        }

        public Category GetCategory(string name)
        {
            return context.Categories.Where(p => p.Name == name).FirstOrDefault();
        }

        public async Task<bool> AddCategory(Category category)
        {
            await context.Categories.AddAsync(category);
            return Save();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
