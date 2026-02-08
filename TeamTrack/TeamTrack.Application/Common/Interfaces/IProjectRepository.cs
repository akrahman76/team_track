using System;
using TeamTrack.Domain.Entities;

namespace TeamTrack.Application.Common.Interfaces;

public interface IProjectRepository
{
    void Add(Project project);
}
