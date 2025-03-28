namespace Application.Requests;

public class UserPasswordResetRequest
{
    public string Username { get; set; }
    public string EmailAddress { get; set; }
}