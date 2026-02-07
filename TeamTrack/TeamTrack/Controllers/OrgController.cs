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
                    
                //TODO: Need to implement the command handler and repository before this can be uncommented
                // var projectId = await _mediator.Send(command, cancellationToken);
                
                // return CreatedAtAction(
                //     nameof(GetProjectById),
                //     new { organizationId, projectId },
                //     null);

                return Ok();
            }
    }
}
