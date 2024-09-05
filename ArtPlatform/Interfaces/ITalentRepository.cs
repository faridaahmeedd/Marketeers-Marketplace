using ArtPlatform.Models;

namespace ArtPlatform.Interfaces
{
    public interface ITalentRepository
    {
        List<Talent> GetAll();
        Talent GetTalent(string id);
        List<Talent> GetTalentsOfCategory(string name);
    }
}
