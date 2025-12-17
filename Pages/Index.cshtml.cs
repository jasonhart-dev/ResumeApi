using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeApi.Services;
using System.ComponentModel.DataAnnotations;

namespace ResumeApi.Pages;

public class IndexModel : PageModel
{
    private readonly IEmailService _emailService;

    public IndexModel(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [TempData]
    public string? Message { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        bool added = _emailService.Store(Email);

       // _emailService.Store(Email);

        _emailService.GetAll();

        if (added)
        {
            Message = $"Thanks! Email captured: {Email}";
        }
        else
            { Message =  $"Email already registered: {Email}";
        }
        Email = string.Empty;

        return RedirectToPage();
    }
}
