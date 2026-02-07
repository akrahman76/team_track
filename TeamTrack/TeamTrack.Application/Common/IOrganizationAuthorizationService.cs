using System;
using TeamTrack.Domain.Enums;

namespace TeamTrack.Application.Common;

public interface IOrganizationAuthorizationService
{
    Task<bool> HasRequiredRoleAsync(
        Guid userId, 
        Guid organizationId, 
        OrganizationRole minimumRole,
        CancellationToken cancellationToken);
}
