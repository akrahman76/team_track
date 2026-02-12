using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamTrack.Application.Command;
using TeamTrack.DTO;

namespace TeamTrack.Controllers;

[Route("api/task")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator; //Need to understand mediator

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Policy = "OrgMember")]
    [HttpPost("projects/{projectId}/create")]
    public async Task<IActionResult> CreateTask(
        Guid projectId,
        [FromBody] CreateTaskRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateTaskCommand(
            projectId,
            request.Name,
            request.Description);

        var taskId = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(CreateTask), new {projectId,taskId}, null); 
    }
}