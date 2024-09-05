namespace ArtPlatform.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; } = "NA";
        public required Talent Talent { get; set; }
    }
}
