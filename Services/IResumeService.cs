using ResumeApi.Dtos;

namespace ResumeApi.Services;

    public interface IResumeService
    {
        ProfileDto GetProfile();
        IEnumerable<SkillDto> GetSkills();
        IEnumerable<ExperienceDto> GetExperience();
    }

