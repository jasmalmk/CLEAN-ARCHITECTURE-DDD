using BuberDinner.Application.Common.Interface.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistance;
public class UserRepository : IUserRepository
{
    private readonly static List<User> _users=new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u=>u.Email==email);
    }
}