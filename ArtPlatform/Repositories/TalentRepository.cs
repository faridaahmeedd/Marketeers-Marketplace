using ArtPlatform.Data;
using ArtPlatform.Interfaces;
using ArtPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtPlatform.Repositories
{
    public class TalentRepository : ITalentRepository
    {
        private readonly DataContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TalentRepository(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public List<Talent> GetAll()
        {
            return context.Talents.Include(p => p.Category).ToList();
        }
        public Talent GetTalent(string id)
        {
            return context.Talents.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefault();
        }

        public List<Talent> GetTalentsOfCategory(string name)
        {
            return context.Talents.Include(p => p.Category).Where(p => p.Category.Name == name).ToList();
        }

        //public Talent GetTalentOfBrand(int id)
        //{
        //    return context.Talents.Where(p => p.Brand.Id == id).Include(p => p.Brand).FirstOrDefault();
        //}

        //public async Task<bool> AddTalent(Talent Talent)
        //{
        //    Talent.Brand = context.Brands.FirstOrDefault();
        //    await context.Talents.AddAsync(Talent);
        //    return Save();
        //}

        //public bool Save()
        //{
        //    var saved = context.SaveChanges();
        //    return saved > 0 ? true : false;
        //}

        //public string UploadImage(IFormFile Image, string TalentId)
        //{
        //    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");

        //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
        //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //    {
        //        Image.CopyTo(fileStream);
        //        fileStream.Close();
        //    }
        //}
    }
}
