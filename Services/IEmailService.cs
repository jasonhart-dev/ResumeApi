using ResumeApi.Dtos;

namespace ResumeApi.Services
{
    public interface IEmailService
    {
        void StoreEmail(string email);
        IEnumerable<string> GetEmails();
    }
}
