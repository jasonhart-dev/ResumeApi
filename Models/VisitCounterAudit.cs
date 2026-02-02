namespace ResumeApi.Models
{
    public class VisitCounterAudit
    {
        public int Id { get; set; }
        public long PreviousVisitCount { get; set; }
        public long NewVisitCount { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Action { get; set; } = "Increment";
    }
}