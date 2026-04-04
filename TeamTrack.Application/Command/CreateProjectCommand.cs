namespace TeamTrack.Application.Command;
using MediatR;

public sealed record CreateProjectCommand(
    Guid OrganizationId,
    string Name,
    string? Description) : IRequest<Guid>;
