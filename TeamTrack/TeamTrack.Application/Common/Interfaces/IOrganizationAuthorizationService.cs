using System;
using TeamTrack.Domain.Enums;

namespace TeamTrack.Application.Common.Interfaces;

public interface IOrganizationAuthorizationService
{
    Task<bool> HasRequiredRoleAsync(
        Guid userId, 
        Guid organizationId, 
        OrganizationRole minimumRole,
        CancellationToken cancellationToken);
}
