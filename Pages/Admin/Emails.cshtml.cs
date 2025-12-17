using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeApi.Services;

namespace ResumeApi.Pages.Admin
{
    public class AdminEmailsModel : PageModel
    {
        private readonly IEmailService _emailService;

        public AdminEmailsModel(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IReadOnlyList<string> Emails { get; private set; } = [];

        public void OnGet()
        {
            Emails = _emailService.GetAll();
        }
    }
}
