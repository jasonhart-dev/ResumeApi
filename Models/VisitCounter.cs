namespace ResumeApi.Models
{
    public class VisitCounter
    {
        public int Id { get; set; }
        public long TotalVisits { get; set; } = 0;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
