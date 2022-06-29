using BuberDinner.Api.Filters;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
// [Route("[controller]")]
[Route("auth")]
// [ErrorHandlingFilter]
public class AuthenticationController : ControllerBase
{

  private readonly IAuthenticationService _authenticationService;

  public AuthenticationController(IAuthenticationService authenticationService)
  {
    _authenticationService = authenticationService;
  }

    // [HttpPost("register")]
    // public IActionResult Register(RegisterRequest request)
    // {
    //     var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
    //     var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);
    //     return Ok(response);
    // }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authenticationResult = _authenticationService.Register(request.FirstName,
                                                                   request.LastName,
                                                                   request.Email,
                                                                   request.Password);

        var response = new AuthenticationResponse(
            authenticationResult.User.Id,
            authenticationResult.User.FirstName,
            authenticationResult.User.LastName,
            authenticationResult.User.Email,
            authenticationResult.Token);

        return Ok(response);
    }

    // [Route("login")]
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authenticationResult = _authenticationService.Login(request.Email,
                                                                request.Password);

        var response = new AuthenticationResponse(
            authenticationResult.User.Id,
            authenticationResult.User.FirstName,
            authenticationResult.User.LastName,
            authenticationResult.User.Email,
            authenticationResult.Token);
            
        return Ok(response);
    }
    
    // [HttpPost("login")]
    // public IActionResult Login(LoginRequest request)
    // {
    //     var authResult = _authenticationService.Login(request.Email, request.Password);
    //     var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);
    //     return Ok(response);
    // }
}
