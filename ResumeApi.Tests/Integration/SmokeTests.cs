using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ResumeApi.Tests.Integration
{
    public class SmokeTests : IClassFixture<WebApplicationFactory<ResumeApi.Program>>
    {
        private readonly HttpClient _client;

        public SmokeTests(WebApplicationFactory<ResumeApi.Program> factory)
        {
            _client =factory.CreateClient();    
        }

        [Fact]
        public async Task Resume_summary_returns_200()
        {
            var resp = await _client.GetAsync("/api/v2/resume/summary");
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }

        [Fact]
        public async Task Swagger_ui_returns_200()
        {
            var resp = await _client.GetAsync("/swagger/index.html");
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }
    }
}
