using TeamTrack.Domain.Entities;

namespace TeamTrack.Application.Common.Interfaces;

public interface ITaskItemRepository
{
    void Add(TaskItem task);
}