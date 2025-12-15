using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResumeApi.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string? Email { get; set; }
    [TempData]
    public string? Message { get; set; }

    public IActionResult OnPost()
    {
        Message = $"Thanks! Email captured: {Email}";
        Email = null ;

        return RedirectToPage();
    }
}
