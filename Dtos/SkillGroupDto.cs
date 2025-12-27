using System.Security.Cryptography.X509Certificates;

namespace ResumeApi.Dtos
{
    public class SkillGroupDto
    {
        public string Category { get; set; } = string.Empty;
        public IReadOnlyList<string> Skills { get; set; } = Array.Empty<string>();  
    }
}
