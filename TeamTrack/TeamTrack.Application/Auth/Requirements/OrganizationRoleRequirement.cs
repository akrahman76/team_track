using System;
using Microsoft.AspNetCore.Authorization;
using TeamTrack.Domain.Enums;

namespace TeamTrack.Application.Auth.Requirements;

public sealed class OrganizationRoleRequirement : IAuthorizationRequirement
{
    public OrganizationRole MinimumRole { get; }

    public OrganizationRoleRequirement(OrganizationRole minimumRole)
    {
        MinimumRole = minimumRole;
    }
}
