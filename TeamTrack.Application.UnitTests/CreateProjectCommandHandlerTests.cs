using System;
using FluentAssertions;
using Moq;
using TeamTrack.Application.Command;
using TeamTrack.Application.CommandHandler;
using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Domain.Entities;

namespace TeamTrack.Application.UnitTests;

public class CreateProjectCommandHandlerTests
{
     [Fact]
    public async Task Creates_project_and_returns_id()
    {
        // Arrange
        var repository = new Mock<IProjectRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();

        var handler = new CreateProjectCommandHandler(
            repository.Object,
            unitOfWork.Object);

        var command = new CreateProjectCommand(
            Guid.NewGuid(),
            "Test Project",
            "Description");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        repository.Verify(r => r.Add(It.IsAny<Project>()), Times.Once);
        unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        result.Should().NotBe(Guid.Empty);
    }
}
