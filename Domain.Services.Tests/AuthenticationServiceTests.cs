using Common.Exceptions;
using Data.Repositories.Abstractions;
using Domain.Models;
using Domain.Services.Implementations;
using Moq;
using FluentAssertions;
using Shared.Queueing.Abstractions;
using Shared.Queueing.Messages;

namespace Domain.Services.Tests;

public class AuthenticationServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IQueueService> _mockQueueService;
    private readonly AuthenticationService _authenticationService;

    public AuthenticationServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockQueueService = new Mock<IQueueService>();
        _authenticationService = new AuthenticationService(_mockUserRepository.Object, _mockQueueService.Object);
    }

    [Fact]
    public async Task ResetPassword_EnqueuesMessage_WhenUserExistsAndEmailMatches()
    {
        // Arrange
        string username = "testuser";
        string emailAddress = "testuser@example.com";
        
        User user = new()
        {
            Username = username,
            EmailAddress = emailAddress
        };
        
        _mockUserRepository
            .Setup(repo => repo.GetUserByUsernameAsync(username))
            .ReturnsAsync(user);
        
        PasswordResetMessage? capturedMessage = null;
        _mockQueueService
            .Setup(service => service.EnqueuePasswordResetMessage(It.IsAny<PasswordResetMessage>()))
            .Callback<PasswordResetMessage>(msg => capturedMessage = msg)
            .Returns(Task.CompletedTask);

        // Act
        await _authenticationService.ResetPassword(username, emailAddress);

        // Assert
        capturedMessage.Should().NotBeNull();
        capturedMessage!.Username.Should().Be(username);
        capturedMessage.EmailAddress.Should().Be(emailAddress);
        capturedMessage.ResetToken.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task ResetPassword_ThrowsNotFoundException_WhenUserDoesNotExist()
    {
        // Arrange
        string username = "nonexistentuser";
        string emailAddress = "nonexistentuser@example.com";
        
        _mockUserRepository
            .Setup(repo => repo.GetUserByUsernameAsync(username))
            .ReturnsAsync((User)null!);

        // Act
        Func<Task> act = async () => await _authenticationService.ResetPassword(username, emailAddress);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"User with username '{username}' not found.");
    }

    [Fact]
    public async Task ResetPassword_ThrowsNotFoundException_WhenEmailDoesNotMatch()
    {
        // Arrange
        string username = "testuser";
        string emailAddress = "wrongemail@example.com";
        
        User user = new()
        {
            Username = username,
            EmailAddress = "testuser@example.com"
        };
        
        _mockUserRepository
            .Setup(repo => repo.GetUserByUsernameAsync(username))
            .ReturnsAsync(user);

        // Act
        Func<Task> act = async () => await _authenticationService.ResetPassword(username, emailAddress);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage("User email address does not match our records.");
    }
}
