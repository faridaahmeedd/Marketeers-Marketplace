using ArtPlatform.Data;
using ArtPlatform.Interfaces;
using ArtPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArtPlatform.Repositories
{
    public class TalentRepository : ITalentRepository
    {
        private readonly DataContext context;
        private readonly UserManager<AppUser> userManager;

        public TalentRepository(DataContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
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

        public async Task<bool> CreateProfile(Talent updatedTalent)
        {
            var existingTalent = await context.Talents.FirstOrDefaultAsync(t => t.Id == updatedTalent.Id);
            if (existingTalent == null)
            {
                return false;
            }

            existingTalent.FName = updatedTalent.FName;
            existingTalent.LName = updatedTalent.LName;
            existingTalent.MobileNumber = updatedTalent.MobileNumber;
            existingTalent.Bio = updatedTalent.Bio;
            existingTalent.Country = updatedTalent.Country;
            existingTalent.City = updatedTalent.City;
            existingTalent.Category = updatedTalent.Category;

            context.Talents.Update(existingTalent);
            return Save();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
