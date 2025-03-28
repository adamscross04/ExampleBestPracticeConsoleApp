using Domain.Models;

namespace Domain.Services.Abstractions;

public interface IAuthenticationService
{
    Task<User?> Login(string username, string password);
    Task<User> Register(User map);
    Task ResetPassword(string username, string emailAddress);
}