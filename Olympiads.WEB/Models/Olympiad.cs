namespace Olympiads.WEB.Models
{
    public class Olympiad
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Subject { get; set; }
    }
}