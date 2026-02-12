using FluentAssertions;
using Moq;
using TeamTrack.Application.Command;
using TeamTrack.Application.CommandHandler;
using TeamTrack.Application.Common.Interfaces;
using TeamTrack.Domain.Entities;

namespace TeamTrack.Application.UnitTests;

public class CreateTaskItemCommandHandlerTest
{
    [Fact]
    public async Task Creates_task_and_returns_id()
    {
        //Arrange
        var repository = new Mock<ITaskItemRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        
        var handler = new CreateTaskCommandHandler(
            repository.Object,
            unitOfWork.Object);
        
        var command = new CreateTaskCommand(
            Guid.NewGuid(),
            "Test Item",
            "This is a test item");
        
        //Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        //Assert
        repository.Verify(r=>r.Add(It.IsAny<TaskItem>()),Times.Once);
        unitOfWork.Verify(u=>u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        result.Should().NotBe(Guid.Empty);
    }
    
}