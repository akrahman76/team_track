using System;
using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Infrastructure.Persistence;

namespace TeamTrack.Infrastructure.Repositories;

public sealed class OrganizationMemberRepository : IOrganizationMemberRepository
{
    private readonly AppDbContext _context;

    public OrganizationMemberRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(TeamTrack.Domain.Entities.OrganizationMember organizationMember)
    {
        _context.OrganizationMembers.Add(organizationMember);
    }
}
