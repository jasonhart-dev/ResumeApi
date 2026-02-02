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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial visit counter
            modelBuilder.Entity<VisitCounter>().HasData(
                new VisitCounter { Id = 1, TotalVisits = 0, LastUpdated = new DateTime(2026,2,1,16,0,0,DateTimeKind.Utc) }
            );
        }
    }
}
