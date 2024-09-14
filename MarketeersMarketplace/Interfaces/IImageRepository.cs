namespace MarketeersMarketplace.Interfaces
{
    public interface IImageRepository
    {
        bool UploadImage(IFormFile Image, string TalentId);
        List<IFormFile> GetImagesOfTalent(string id);
        bool DeleteImage(string imageUrl);
        bool Save();
    }
}
