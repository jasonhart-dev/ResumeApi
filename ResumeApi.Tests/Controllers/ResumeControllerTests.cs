//using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ResumeApi.Controllers.V2;
using ResumeApi.Dtos;
using ResumeApi.Services;
using Xunit;

namespace ResumeApi.Tests.Controllers;

public class ResumeControllerTests
{
    private readonly Mock<IResumeService> _resumeServiceMock = new();
    private readonly ResumeController _controller;

    public ResumeControllerTests()
    {
        _controller = new ResumeController(_resumeServiceMock.Object);
    }

    [Fact]
    public void GetSummary_returns_Ok_with_summary_dto()
    {
        // Arrange
        var summary = new ResumeSummaryDto
        {
            Name = "Jason Hart",
            Title = ".NET Developer",
            ProfessionalSummary = "Test summary"
        };

        _resumeServiceMock
            .Setup(s => s.GetSummary())
            .Returns(summary);

        // Act
        var result = _controller.GetSummary();

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Same(summary, ok.Value);
    }

    [Fact]
    public void GetExperienceById_when_not_found_returns_404()
    {
        // Arrange
        _resumeServiceMock
            .Setup(s => s.GetExperienceById(99))
            .Returns((ExperienceDto?)null);

        // Act
        var result = _controller.GetExperienceById(99);

        // Assert
        Assert.NotSame(result, null);
    }

    [Fact]
    public void GetExperienceById_when_found_returns_200_with_experience_dto()
    {
        // Arrange
        var experience = new ExperienceDto
        {
            Id = 1,
            Company = "Test Company",
            Title = "Senior Developer",
            DateRange = "2020–2024",
            Location = "Houston, TX",
            Responsibilities = new[] { "Built APIs", "Wrote tests" },
            Environment = new[] { "C#", ".NET", "SQL Server" }
        };

        _resumeServiceMock
            .Setup(s => s.GetExperienceById(1))
            .Returns(experience);

        // Act
        var result = _controller.GetExperienceById(1);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Same(experience, ok.Value);
    }
}
