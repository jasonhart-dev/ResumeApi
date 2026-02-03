namespace ResumeApi.Models
{
    public class CapturedEmail
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public string SourcePage { get; set; } = "HomePage";
    }
}
