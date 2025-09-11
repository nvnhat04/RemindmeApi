namespace RemindMeApi.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Content { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
