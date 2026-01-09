using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using ResumeApi.Dtos;
using Xunit;

namespace ResumeApi.Tests.Integration
{
    public class ResumeEndpointsTests : IClassFixture<WebApplicationFactory<ResumeApi.Program>>
    {
        private readonly HttpClient _client;
        public ResumeEndpointsTests(WebApplicationFactory<ResumeApi.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]  
        public async Task Get_summary_returns_payload_with_required_fields()
        {
            var resp = await _client.GetAsync("/api/v2/resume/summary");

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);

            var dto = await resp.Content.ReadFromJsonAsync<ResumeSummaryDto>();
            Assert.NotNull(dto);

            Assert.False(string.IsNullOrWhiteSpace(dto!.Name), "Name should not be empty");
            Assert.False(string.IsNullOrWhiteSpace(dto.Title), "Title should not be empty");
            Assert.False(string.IsNullOrWhiteSpace(dto.ProfessionalSummary), "ProfessionalSummary should not be empty");

        }

        [Fact]
        public async Task Get_experience_by_id_when_missing_returns_404()
        {
            var resp = await _client.GetAsync("/api/v2/resume/experience/99999");
            Assert.Equal(HttpStatusCode.NotFound, resp.StatusCode);
        }
    }
}
