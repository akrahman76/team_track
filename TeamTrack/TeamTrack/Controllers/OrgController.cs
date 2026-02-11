using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTrack.Application.Command;
using TeamTrack.DTO;

namespace TeamTrack.Controllers
{
    [Route("api/org")]
    [ApiController]
    public class OrgController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrgController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "OrgAdmin")]
        [HttpPost("organizations/{organizationId}/projects")]
        public async Task<IActionResult> CreateProject(
            Guid organizationId,
            [FromBody] CreateProjectRequest request,
            CancellationToken cancellationToken)
            {
                var command = new CreateProjectCommand(
                    organizationId,
                    request.Name,
                    request.Description);
                    
                var projectId = await _mediator.Send(command, cancellationToken);

                return CreatedAtAction(nameof(CreateProject), new { organizationId, projectId }, null);
            }

        [HttpPost("organizations")]
        public async Task<IActionResult> CreateOrganization(
            [FromBody] CreateOrganizationRequest request,
            CancellationToken cancellationToken)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var command = new CreateOrganizationCommand(
                request.Name,
                currentUserId);

            var organizationId = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(nameof(CreateOrganization), new { organizationId }, null);
        }
    }
}
