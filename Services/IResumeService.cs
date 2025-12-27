using ResumeApi.Dtos;

namespace ResumeApi.Services;

    public interface IResumeService
    {
        ResumeSummaryDto GetSummary();
        IReadOnlyList<SkillGroupDto> GetSkills();
        IReadOnlyList<ExperienceDto> GetExperience();
        ExperienceDto? GetExperienceById(int id);
        EducationDto GetEducation();
    }

