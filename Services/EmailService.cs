using ResumeApi.Dtos;

namespace ResumeApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly List<string> _emails = new();

        public bool Store(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            //if (_emails.Contains(email, StringComparer.OrdinalIgnoreCase))
            if (_emails.Any(e => e.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return false;

                _emails.Add(email);
            return true;
        }
        //public IReadOnlyList<string> GetAll() => _emails;
        public IReadOnlyList<string> GetAll() => _emails;
    }
}
