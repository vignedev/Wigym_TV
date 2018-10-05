namespace TV.Models
{
    public class Image : IDisplayObject
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}