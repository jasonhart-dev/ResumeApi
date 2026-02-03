using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeApi.Services;
using System.ComponentModel.DataAnnotations;

namespace ResumeApi.Pages;

public class IndexModel : PageModel
{
    private readonly IEmailService _emailService;
    private readonly IEmailPersistenceService _emailPersistenceService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(IEmailService emailService, IEmailPersistenceService emailPersistenceService, ILogger<IndexModel> logger  )
    {
        _emailService = emailService;
        _emailPersistenceService = emailPersistenceService;
        _logger = logger;
    }

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [TempData]
    public string? Message { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            // Save to database first
            bool saveToDb = await _emailPersistenceService.SaveEmailAsync(Email, "HomePage");

            if (saveToDb)
            {
                // Also store in memory for existing functionality
                _emailService.Store(Email);

                Message = $"Thanks! Email captured: {Email}";
                _logger.LogInformation("Email {Email} successfully captured and saved to database", Email);
            }
            else
            {
                Message = "There was an error saving your email. Please try again.";
                _logger.LogWarning("Failed to save email {Email} to database", Email);
                return Page();
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error capturing email {Email}", Email);
            Message = "An error occurred. Please try again later.";
            return Page();
        }

        Email = string.Empty;
        return RedirectToPage("/Resume");

    }
}
