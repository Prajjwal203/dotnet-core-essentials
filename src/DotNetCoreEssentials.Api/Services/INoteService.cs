using System;
using DotNetCoreEssentials.Api.Models;


namespace DotNetCoreEssentials.Api.Services
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetAllAsync();
        Task<Note?> GetByIdAsync(Guid id);
        Task<Note> CreateAsync(Note note);
        Task<bool> DeleteAsync(Guid id);
    }
}