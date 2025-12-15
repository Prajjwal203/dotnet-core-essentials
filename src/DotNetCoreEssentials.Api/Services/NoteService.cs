using System;
using DotNetCoreEssentials.Api.Models;

namespace DotNetCoreEssentials.Api.Services
{
    public class NoteService : INoteService
    {
        private readonly List<Note> _store = new();

        public Task<IEnumerable<Note>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Note>>(_store);
        }

        public Task<Note?> GetByIdAsync(Guid id)
        {
            var note = _store.FirstOrDefault(n => n.Id == id);
            return Task.FromResult(note);
        }

        public Task<Note> CreateAsync(Note note)
        {
            _store.Add(note);
            return Task.FromResult(note);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var note = _store.FirstOrDefault(n => n.Id == id);
            if (note == null)
                return Task.FromResult(false);

            _store.Remove(note);
            return Task.FromResult(true);
        }
    }
}