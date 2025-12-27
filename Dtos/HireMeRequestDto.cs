namespace ResumeApi.Dtos
{
    public class HireMeRequestDto
    {
        public string Company { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
