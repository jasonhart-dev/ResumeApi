using ResumeApi.Data;
using ResumeApi.Models;

namespace ResumeApi.Services
{
    public interface IVisitCounterService
    {
        Task<long> IncrementVisitAsync();
        Task<long> GetVisitCountAsync();
    }

    public class VisitCounterService : IVisitCounterService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VisitCounterService> _logger;

        public VisitCounterService(ApplicationDbContext context, ILogger<VisitCounterService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<long> IncrementVisitAsync()
        {
            try
            {
                var counter = await _context.VisitCounters.FindAsync(1);
                if (counter == null)
                {
                    counter = new VisitCounter { Id = 1, TotalVisits = 1, LastUpdated = DateTime.UtcNow };
                    _context.VisitCounters.Add(counter);
                }
                else
                {
                    counter.TotalVisits++;
                    counter.LastUpdated = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();
                return counter.TotalVisits;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error incrementing visit counter");
                throw;
            }
        }

        public async Task<long> GetVisitCountAsync()
        {
            try
            {
                var counter = await _context.VisitCounters.FindAsync(1);
                return counter?.TotalVisits ?? 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving visit counter");
                return 0;
            }
        }
    }
}