using System;

namespace TeamTrack.DTO;

public sealed class CreateProjectRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}