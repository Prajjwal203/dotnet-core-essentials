using System;
using System.Net;
using System.Net.Http.Json;
using DotNetCoreEssentials.Api.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;


namespace DotNetCoreEssentials.Tests
{
    public class NotesControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public NotesControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostAndGetNote_ReturnsCreatedNote()
        {
            // Arrange
            var request = new NoteDto(
                Guid.Empty,
                "Integration Test",
                "Created via integration test",
                DateTime.UtcNow
            );

            // Act - POST
            var postResponse = await _client.PostAsJsonAsync("/api/notes", request);

            // Assert POST
            Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);

            var created = await postResponse.Content.ReadFromJsonAsync<NoteDto>();
            Assert.NotNull(created);

            // Act - GET
            var getResponse = await _client.GetAsync($"/api/notes/{created!.Id}");

            // Assert GET
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

        }

    }

}
