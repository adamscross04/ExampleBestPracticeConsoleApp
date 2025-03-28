using Common.Exceptions;
using Data.Repositories.Abstractions;
using Domain.Models;
using Domain.Services.Abstractions;
using Shared.Queueing.Abstractions;
using Shared.Queueing.Messages;

namespace Domain.Services.Implementations;

public class AuthenticationService(IUserRepository userRepository, IQueueService queueService) : IAuthenticationService
{
    public Task<User?> Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<User> Register(User map)
    {
        throw new NotImplementedException();
    }

    public async Task ResetPassword(string username, string emailAddress)
    {
        // Retrieve the user by username.
        User user = await userRepository.GetUserByUsernameAsync(username) ?? throw new NotFoundException($"User with username '{username}' not found.");

        // Ensure the provided email address matches the user's email.
        if (!string.Equals(user.EmailAddress, emailAddress, StringComparison.OrdinalIgnoreCase))
        {
            throw new NotFoundException("User email address does not match our records.");
        }

        // Generate a reset token (using a GUID for demonstration purposes).
        string resetToken = Guid.NewGuid().ToString();

        // Create a message to be enqueued.
        PasswordResetMessage resetMessage = new()
        {
            Username = username,
            EmailAddress = emailAddress,
            ResetToken = resetToken
        };

        // Enqueue the message. The data/infrastructure layer handles all queuing logic.
        await queueService.EnqueuePasswordResetMessage(resetMessage);
    }
}