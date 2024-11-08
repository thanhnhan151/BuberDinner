using BuberDinner.Domain.User;

namespace BuberDinner.Application.Persistence;

public interface IUserRepository
{
    User? GetUserByEmailAsync(string email);
    void AddAsync(User user);
}
