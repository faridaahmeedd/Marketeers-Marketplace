using MarketeersMarketplace.Models;
using MarketeersMarketplace.Interfaces;
using MarketeersMarketplace.Data;

namespace MarketeersMarketplace.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly DataContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ITalentRepository talentRepository;

        public ImageRepository(DataContext context, IWebHostEnvironment webHostEnvironment, ITalentRepository talentRepository)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
            this.talentRepository = talentRepository;
        }

        public bool UploadImage(IFormFile Image, string TalentId)
        {
            var talent = talentRepository.GetTalent(TalentId);
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");

            string uniqueFileName = TalentId + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
                fileStream.Close();
            }
            context.Images.AddAsync(new Image() { Path = uniqueFileName, Talent = talent });
            return Save();
        }

        public List<IFormFile> GetImagesOfTalent(string id)
        {
            var imagePaths = context.Images
                .Where(i => i.Talent.Id == id)
                .Select(i => i.Path)
                .ToList();

            var files = imagePaths.Select(path => CreateFormFile(path)).ToList();
            return files;
        }


        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }

        private IFormFile CreateFormFile(string fileName)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            string filePath = Path.Combine(uploadsFolder, fileName);
            var fileInfo = new FileInfo(filePath);
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return new FormFile(fileStream, 0, fileInfo.Length, fileInfo.Name, fileInfo.Name);
        }

        public bool DeleteImage(string imageUrl)
        {
            try
            {
                var image = context.Images.Where(i => i.Path == imageUrl).FirstOrDefault();
                context.Images.Remove(image);
                Save();
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                string filePath = Path.Combine(uploadsFolder, imageUrl);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
