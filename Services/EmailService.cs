using ResumeApi.Dtos;

namespace ResumeApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly List<string> _emails = new();

        public void StoreEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
                _emails.Add(email);
        }
        public IEnumerable<string> GetEmails() => _emails;
    }
}
