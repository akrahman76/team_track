namespace TeamTrack.Application.Command;
using MediatR;

public sealed record class CreateOrganizationCommand(
    string Name,
    Guid CurrentUserId
) : IRequest<Guid>;
