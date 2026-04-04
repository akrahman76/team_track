using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Domain.Entities;
using TeamTrack.Infrastructure.Persistence;

namespace TeamTrack.Infrastructure.Repositories;

public class TaskItemRepository : ITaskItemRepository
{
    private readonly AppDbContext _dbContext;

    public TaskItemRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(TaskItem task)
    {
        _dbContext.Tasks.Add(task);
    }
}