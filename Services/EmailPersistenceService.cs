using Microsoft.EntityFrameworkCore;
using ResumeApi.Data;
using ResumeApi.Models;

namespace ResumeApi.Services
{
    public interface IEmailPersistenceService
    {
        Task<bool> SaveEmailAsync(string email, string sourcePage = "HomePage");
        Task<List<CapturedEmail>> GetAllEmailsAsync();
        Task<List<CapturedEmail>> GetEmailsAsync(DateTime from,  DateTime to);

        Task<bool> DeleteEmailAsync(int id);
    }
    
    public class EmailPersistenceService : IEmailPersistenceService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmailPersistenceService> _logger;

        public EmailPersistenceService(ApplicationDbContext context, ILogger<EmailPersistenceService> logger)
        {
            _context = context;
            _logger = logger;   
        }

        public async Task<bool> SaveEmailAsync(string email, string sourcePage = "HomePage")
        {
            try
            {
                var capturedEmail = new CapturedEmail
                {
                    Email = email,
                    SourcePage = sourcePage,
                    SubmittedAt = DateTime.UtcNow
                };

                _context.CapturedEmails.Add(capturedEmail);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Email {Email} saved from {SourcePage}", email, sourcePage);
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving email {Email}", email);
                return false;
            }

        }
        public async Task<List<CapturedEmail>> GetAllEmailsAsync()
        {
            try
            {
                return await _context.CapturedEmails
                    .OrderByDescending(e => e.SubmittedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all emails");
                return new List<CapturedEmail>();
            }
        }
        public async Task<List<CapturedEmail>> GetEmailsAsync(DateTime from, DateTime to)
        {
            try
            {
                return await _context.CapturedEmails
                    .Where(e => e.SubmittedAt >= from && e.SubmittedAt <= to)
                    .OrderByDescending(e => e.SubmittedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving emails for date range");
                return new List<CapturedEmail>();
            }
        }

        public async Task<bool> DeleteEmailAsync(int id)
        {
            try
            {
                var email = await _context.CapturedEmails.FindAsync(id);
                if (email == null)
                {
                    _logger.LogWarning("Email with id {Id} not found", id);
                    return false;
                }

                _context.CapturedEmails.Remove(email);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Email with id {Id} deleted", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting email with id {Id}", id);
                return false;
            }
        }
    }
}
