using System;
using TeamTrack.Domain.Enums;

namespace TeamTrack.Application.Common;

public interface IOrgranizationAuthorizationService
{
    Task<bool> HasRequiredRoleAsync(
        Guid userId, 
        Guid organizationId, 
        OrganizationRole minimumRole,
        CancellationToken cancellationToken);
}
