using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1.  Validate the user does exist.
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist.");
        }

        // 2.  Validate the password is correct.

        if(user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        // 3.  Generate a JWT token.

        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // 1. VAlidate the user doenst exist already

        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists.");
        }

        // 2 Crete the user (getneated id and persist to db)

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);
        
        // 3. Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token);
    }
}