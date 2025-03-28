using Application.DTOs;
using Application.Mappers.Abstractions;
using Application.Requests;
using Common.Exceptions;
using Domain.Models;
using Domain.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApi.Controllers;

[ApiController]
[Route("api/authenticate")]
public class AuthenticationController(IAuthenticationService authenticationService, IUserDtoMapper userDtoMapper)
    : ControllerBase
{
    // login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
    {
        try
        {
            User? user = await authenticationService.Login(loginRequest.Username, loginRequest.Password);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        catch (Exception e)
        {
            // Log exception (ex) here as needed.
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    // register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        try
        {
            User user = await authenticationService.Register(userDtoMapper.Map(userDto));
            return Ok(user);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
        catch (Exception e)
        {
            // Log exception (ex) here as needed.
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    // reset password
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] UserPasswordResetRequest userPasswordResetRequest)
    {
        try
        {
            await authenticationService.ResetPassword(userPasswordResetRequest.Username,
                userPasswordResetRequest.EmailAddress);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
        catch (Exception e)
        {
            // Log exception (ex) here as needed.
            return StatusCode(500, "An unexpected error occurred.");
        }
    }
}