using MarketeersMarketplace.Models;

namespace MarketeersMarketplace.Interfaces
{
    public interface ITalentRepository
    {
        List<Talent> GetAll();
        Talent GetTalent(string id);
        List<Talent> GetTalentsOfCategory(string category);
        List<Talent> GetTalentsByName(string name);
        Task<bool> CreateProfile(Talent Talent);
    }
}
