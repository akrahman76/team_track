using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Application.Auth.Requirements;
using TeamTrack.Infrastructure.Persistence;

namespace TeamTrack.Infrastructure.Auth.Handlers;

public class OrganizationRoleAuthorizationHandler: AuthorizationHandler<OrganizationRoleRequirement>
{
    private readonly IOrganizationAuthorizationService _authService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public OrganizationRoleAuthorizationHandler(
        IOrganizationAuthorizationService authService,
        IHttpContextAccessor httpContextAccessor,
        AppDbContext context)
    {
        _authService = authService;
        _httpContextAccessor = httpContextAccessor;
        _context = context;
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
        
        Guid organizationId;
        var routeValues = httpContext.Request.RouteValues;

        if (routeValues.ContainsKey("organizationId"))
        {
            organizationId = Guid.Parse(routeValues["organizationId"].ToString());
        }
        else if (routeValues.ContainsKey("projectId"))
        {
            var projectId = Guid.Parse(routeValues["projectId"].ToString());

            var project = await _context.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
                return;

            organizationId = project.OrganizationId;
        }
        else
        {
            return;
        }

        // Assumes route: /organizations/{organizationId}/...
        // if (!httpContext.Request.RouteValues.TryGetValue("organizationId", out var orgIdObj))
        //     return;
        
         // if (!Guid.TryParse(orgIdObj?.ToString(), out var organizationId))
         //    return;

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
