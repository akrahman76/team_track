using MediatR;
using TeamTrack.Application.Command;
using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Domain.Entities;

namespace TeamTrack.Application.CommandHandler;

public sealed class CreateTaskCommandHandler
    : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateTaskCommandHandler(
        ITaskItemRepository taskItemRepository, 
        IUnitOfWork unitOfWork)
    {
        _taskItemRepository = taskItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        CreateTaskCommand request, 
        CancellationToken cancellationToken)
    {
        var taskItem = TaskItem.CreateTaskItem(
            request.ProjectId,
            request.Name);
        
        _taskItemRepository.Add(taskItem);
        
        //need to understand how unit of work working and cancellation token
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return taskItem.Id;
    }
}