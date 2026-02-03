using Microsoft.EntityFrameworkCore;
using ResumeApi.Models;

namespace ResumeApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<VisitCounter> VisitCounters { get; set; } = null!;
        public DbSet<VisitCounterAudit> VisitCountersAudit { get; set; } = null!;

        public DbSet<CapturedEmail> CapturedEmails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure VisitCounters to disable the OUTPUT clause for updates
            // This is required because the table has a trigger
            modelBuilder.Entity<VisitCounter>()
                .ToTable(tb => tb.HasTrigger("trg_VisitCounters_Audit"));

            // Seed initial visit counter
            modelBuilder.Entity<VisitCounter>().HasData(
                new VisitCounter { Id = 1, TotalVisits = 0, LastUpdated = new DateTime(2026,2,1,16,0,0,DateTimeKind.Utc) }
            );
        }
    }
}
