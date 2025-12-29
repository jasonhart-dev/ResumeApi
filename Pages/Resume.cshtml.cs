using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeApi.Dtos;

namespace ResumeApi.Pages
{
    public class ResumeModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ResumeSummaryDto? Summary { get; set; }
        public IReadOnlyList<ExperienceDto> Experiences { get; set; } = new List<ExperienceDto>();

        [BindProperty]
        public bool ShowHireMeForm { get; set; }

        [BindProperty]
        public string? Company { get; set; }

        [BindProperty]
        public string? JobTitle { get; set; }

        public ResumeModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private string GetBaseUrl() => $"{Request.Scheme}://{Request.Host}";
        private async Task LoadResumeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            Summary = await client.GetFromJsonAsync<ResumeSummaryDto>($"{GetBaseUrl()}/api/v2/resume/summary");

            Experiences = await client.GetFromJsonAsync<List<ExperienceDto>>(
                $"{GetBaseUrl()}/api/v2/resume/experience")
                ?? new List<ExperienceDto>();
        }

        public async Task OnGetAsync()
        {
            await LoadResumeAsync();
        }
        
        public async Task<IActionResult> OnPostShowHireMeAsync()
        {
            await LoadResumeAsync();
            ShowHireMeForm = true;

            TempData["Message"] = "Hire Me form opened."; // optional
            return Page();
        }

        public async Task<IActionResult> OnPostHireMeAsync()
        {
            await LoadResumeAsync();
            ShowHireMeForm = true; // keep form visible if validation fails

            if (string.IsNullOrWhiteSpace(Company) || string.IsNullOrWhiteSpace(JobTitle))
            {
                TempData["Message"] = "Company and Job Title are required.";
                return Page();
            }

            var client = _httpClientFactory.CreateClient();

            var request = new HireMeRequestDto
            {
                Company = Company!,
                JobTitle = JobTitle!
            };
            var response = await client.PostAsJsonAsync($"{GetBaseUrl()}/api/v2/hireme", request);

            if (response.IsSuccessStatusCode)
            {
                TempData["ViewingFor"] = $"{JobTitle} @ {Company}";
                TempData["Message"] = "Thanks! Your interest has been recorded.";
                TempData.Keep("ViewingFor");

                ShowHireMeForm = false;
                Company = JobTitle = string.Empty;
            }
            else
            {
                TempData["Message"] = "Sorry — something went wrong submitting your request.";
                ShowHireMeForm = true;
            }

            return Page();
        }


        // ✅ Placeholder for the second form (since it currently has method="post" with no handler)
        public async Task<IActionResult> OnPostAsync()
        {
            TempData["Message"] = "Default OnPostAsync was hit (wrong handler)";
            await LoadResumeAsync();
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            // Clear bound properties
            Company = null;
            JobTitle = null;
            ShowHireMeForm = false;

            // Clear TempData
            TempData.Remove("ViewingFor");
            TempData.Remove("ViewingJobTitle");
            TempData.Remove("ViewingCompany");

            return RedirectToPage("/Index");
        }
    }
}
