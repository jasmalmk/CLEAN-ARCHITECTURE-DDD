using BuberDinner.Application.Common.Errors.Exceptions;
using BuberDinner.Application.Common.Interface.Authentication;
using BuberDinner.Application.Common.Interface.Persistance;
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
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //validate user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailExceptions();
        }
        //create user (generate unique id) & Persist to DB
        var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };
        _userRepository.Add(user);
        //Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
    public AuthenticationResult Login(string email, string password)
    {
        //1.validate user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("user with given email not exists");
        }
        //2.validate password
        if (user.Password != password)
        {
            throw new Exception("Invalid Password");
        }
        //3.create Jwt Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}