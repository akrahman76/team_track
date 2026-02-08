using System;
using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Infrastructure.Persistence;

namespace TeamTrack.Infrastructure.Repositories;

public sealed class OrganizationRepository : IOrganizationRepository
{
    private readonly AppDbContext _context;

    public OrganizationRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(TeamTrack.Domain.Entities.Organization organization)
    {
        _context.Organizations.Add(organization);
    }
}
