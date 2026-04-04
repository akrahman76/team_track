using MediatR;

namespace TeamTrack.Application.Command;

public sealed record CreateTaskCommand(
    Guid ProjectId,
    string Name,
    string? Description) : IRequest<Guid>;