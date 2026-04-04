using System;
using MediatR;
using TeamTrack.Application.Command;
using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Domain.Entities;
using TeamTrack.Domain.Enums;

namespace TeamTrack.Application.CommandHandler;

public sealed class CreateOrganizationCommandHandler
    : IRequestHandler<CreateOrganizationCommand, Guid>
{
    private readonly IOrganizationRepository organizationRepository;
    private readonly IOrganizationMemberRepository organizationMemberRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateOrganizationCommandHandler(
        IOrganizationRepository organizationRepository,
        IOrganizationMemberRepository organizationMemberRepository,
        IUnitOfWork unitOfWork)
    {
        this.organizationRepository = organizationRepository;
        this.organizationMemberRepository = organizationMemberRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        CreateOrganizationCommand request, 
        CancellationToken cancellationToken)
    {
        var organization = Organization.Create(request.Name);
        organizationRepository.Add(organization);

        var organizationMember = new OrganizationMember(
            organization.Id, 
            request.CurrentUserId,
            OrganizationRole.Admin);

        organizationMemberRepository.Add(organizationMember);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return organization.Id;
    }
}
