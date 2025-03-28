using Shared.Queueing.Messages;

namespace Shared.Queueing.Abstractions;

public interface IQueueService
{
    Task EnqueuePasswordResetMessage(PasswordResetMessage message);
}