using System;
using DotNetCoreEssentials.Api.Models;
using DotNetCoreEssentials.Api.Services;
using Xunit;


namespace DotNetCoreEssentials.Tests
{
    public class NoteServiceTests
    {
        [Fact]
        public async Task CreateAsync_AddsNoteToStore()
        {
            // Arrange
            var service = new NoteService();
            var note = new Note
            {
                Title = "Test title",
                Content = "Test content"
            };

            // Act
            var created = await service.CreateAsync(note);
            var allNotes = await service.GetAllAsync();

            // Assert
            Assert.Contains(allNotes, n => n.Id == created.Id);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNote_WhenExists()
        {
            // Arrange
            var service = new NoteService();
            var note = await service.CreateAsync(
                new Note { Title = "T", Content = "C" });

            // Act
            var result = await service.GetByIdAsync(note.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(note.Id, result!.Id);
        }

        [Fact]
        public async Task DeleteAsync_RemovesNote_WhenExists()
        {
            // Arrange
            var service = new NoteService();
            var note = await service.CreateAsync(
                new Note { Title = "T", Content = "C" });

            // Act
            var deleted = await service.DeleteAsync(note.Id);
            var all = await service.GetAllAsync();

            // Assert
            Assert.True(deleted);
            Assert.DoesNotContain(all, n => n.Id == note.Id);
        }

    }
}