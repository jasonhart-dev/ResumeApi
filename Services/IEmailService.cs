using ResumeApi.Dtos;

namespace ResumeApi.Services
{
    public interface IEmailService
    {
        /// <summary>
        /// Stores the email if it is not already stored.
        /// Returns true if stored, false if it was a duplicate or invalid.
        /// </summary>
        /// 
        bool Store(string email);

        //void StoreEmail(string email);
        // void Store(string email);
        //IEnumerable<string> GetEmails();
        IReadOnlyList<string> GetAll();
    }
}
