namespace Shared.Queueing.Messages;

public class PasswordResetMessage
{
    public required string Username { get; set; }
    public required string EmailAddress { get; set; }
    public required string ResetToken { get; set; }
}