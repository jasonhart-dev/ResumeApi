using ResumeApi.Dtos;

namespace ResumeApi.Services
{
    public class ResumeService : IResumeService
    {
        public ProfileDto GetProfile()
        {
            return new ProfileDto
            {
                Name = "Jason Hart",
                Title = ".NET Software Developer",
                Summary = "Experienced .NET developer specializing in C#, SQL, VB.NET, and API development."
            };
        }

        public IEnumerable<SkillDto> GetSkills() 
        {
            return new List<SkillDto>
            {
                new SkillDto { Name = "C#", Level = "Expert" },
                new SkillDto { Name = "ASP.NET Core", Level = "Advanced" },
                new SkillDto { Name = "SQL Server", Level = "Advanced" }
            };
        }

        public IEnumerable<ExperienceDto> GetExperience()
        {
            return new List<ExperienceDto>
            {
                new ExperienceDto
                {
                    Company = "Sample Company",
                    Role = "Senior .NET Developer",
                    Technologies = new[] { "C#", "ASP.NET", "SQL" },
                    Highlights = new[]
                    {
                        "Built REST APIs",
                        "Modernized legacy VB.NET apps",
                        "Improved SQL performance"
                    }
                }
            };
        }
    }
}
