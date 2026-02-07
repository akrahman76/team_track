using System;
using Microsoft.EntityFrameworkCore;
using TeamTrack.Application.Common;
using TeamTrack.Domain.Enums;
using TeamTrack.Infrastructure.Persistence;

namespace TeamTrack.Infrastructure.Auth;

public sealed class OrganizationAuthorizationService : IOrganizationAuthorizationService
{
     private readonly AppDbContext _context;

    public OrganizationAuthorizationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> HasRequiredRoleAsync(
         Guid userId,
        Guid organizationId,
        OrganizationRole minimumRole,
        CancellationToken cancellationToken
    )
    {
        var member = await _context.OrganizationMembers
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.UserId == userId && m.OrganizationId == organizationId, cancellationToken);
            
        return member != null && member.Role >= minimumRole;
    }
}
