using System;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreEssentials.Api.Services;
using DotNetCoreEssentials.Api.Models;
using DotNetCoreEssentials.Api.DTOs;


namespace DotNetCoreEssentials.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _service;
        private readonly ILogger<NotesController> _logger;

        public NotesController(INoteService service, ILogger<NotesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _service.GetAllAsync();
            var result = notes.Select(n =>
                new NoteDto(n.Id, n.Title, n.Content, n.CreatedAt));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var note = await _service.GetByIdAsync(id);
            if (note == null)
                return NotFound();

            return Ok(new NoteDto(note.Id, note.Title, note.Content, note.CreatedAt));
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteDto dto)
        {
            var note = new Note
            {
                Title = dto.Title,
                Content = dto.Content
            };

            var created = await _service.CreateAsync(note);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new NoteDto(created.Id, created.Title, created.Content, created.CreatedAt)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
