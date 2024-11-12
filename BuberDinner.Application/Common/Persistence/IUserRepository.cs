using BuberDinner.Domain.User;

namespace BuberDinner.Application.Common.Persistence;

public interface IUserRepository
{
    User? GetUserByEmailAsync(string email);
    void AddAsync(User user);
}
