namespace ResumeApi.Dtos
{
    public class ExperienceDto
    {
        public int Id { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string DateRange { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public IReadOnlyList<string> Responsibilities { get; set; } = Array.Empty<string>();
        public string[] Environment { get; set; }
    }
}
