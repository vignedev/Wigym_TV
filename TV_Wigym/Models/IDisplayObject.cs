namespace TV.Models
{
    public interface IDisplayObject
    {
        string FileName { get; set; }
        int Id { get; set; }
        string Url { get; set; }
    }
}