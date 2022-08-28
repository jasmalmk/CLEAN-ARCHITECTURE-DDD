using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interface.Persistance;
public interface IUserRepository{
    User? GetUserByEmail(string email);

    void Add(User user);
}