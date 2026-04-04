using System;
using MediatR;
using TeamTrack.Application.Command;
using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Domain.Entities;

namespace TeamTrack.Application.CommandHandler;

public sealed class CreateProjectCommandHandler
    : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        CreateProjectCommand request,
        CancellationToken cancellationToken)
    {
        var project = Project.Create(
            request.OrganizationId,
            request.Name,
            request.Description);

        _projectRepository.Add(project);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return project.Id;
    }
}
