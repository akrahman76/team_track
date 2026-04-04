namespace TeamTrack.DTO;

public sealed class CreateTaskRequest
{
    public string Name { get; init; } = default!; //why use !
    public string? Description { get; init; } // why add ? after string
}