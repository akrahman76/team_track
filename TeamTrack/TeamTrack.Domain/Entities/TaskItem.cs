using System;
using System.Collections.Generic;
using System.Text;
using TeamTrack.Domain.Common;
using TeamTrack.Domain.Enums;
using TaskStatus = TeamTrack.Domain.Enums.TaskStatus;

namespace TeamTrack.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public Guid ProjectId { get; private set; }
        public string Title { get; private set; }
        public TaskStatus Status { get; private set; }
        public TaskPriority Priority { get; private set; }

        private TaskItem() { }

        public TaskItem(Guid projectId, string title)
        {
            ProjectId = projectId;
            Title = title;
            Status = TaskStatus.ToDo;
            Priority = TaskPriority.Medium;
        }

        public void Start()
        {
            Status = TaskStatus.InProgress;
        }

        public void Complete()
        {
            Status = TaskStatus.Done;
        }
    }
}
