using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Application.Auth.Requirements;

namespace TeamTrack.Infrastructure.Auth.Handlers;

public class OrganizationRoleAuthorizationHandler: AuthorizationHandler<OrganizationRoleRequirement>
{
    private readonly IOrganizationAuthorizationService _authService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrganizationRoleAuthorizationHandler(
        IOrganizationAuthorizationService authService,
        IHttpContextAccessor httpContextAccessor)
    {
        _authService = authService;
        _httpContextAccessor = httpContextAccessor;
    }

      protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        OrganizationRoleRequirement requirement)
    {
        var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null) return;

        if (!Guid.TryParse(userIdClaim.Value, out var userId)) return;

        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null) return;

        // Assumes route: /organizations/{organizationId}/...
        if (!httpContext.Request.RouteValues.TryGetValue("organizationId", out var orgIdObj))
            return;
        
         if (!Guid.TryParse(orgIdObj?.ToString(), out var organizationId))
            return;

        var hasAccess = await _authService.HasRequiredRoleAsync(
            userId,
            organizationId,
            requirement.MinimumRole,
            CancellationToken.None
        );
        
        if (hasAccess)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}
