using System;

namespace DotNetCoreEssentials.Api.DTOs
{
    public record NoteDto(
        Guid Id,
        string Title,
        string Content,
        DateTime CreatedAt
    );
}
