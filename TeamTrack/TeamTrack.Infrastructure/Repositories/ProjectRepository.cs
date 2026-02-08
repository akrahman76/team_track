using System;
using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Domain.Entities;
using TeamTrack.Infrastructure.Persistence;

namespace TeamTrack.Infrastructure.Repositories;

public sealed class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _dbContext;

    public ProjectRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Project project)
    {
        _dbContext.Projects.Add(project);
    }
}
