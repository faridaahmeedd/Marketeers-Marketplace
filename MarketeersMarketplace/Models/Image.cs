namespace MarketeersMarketplace.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; } = "NA";
        public required Talent Talent { get; set; }
    }
}
