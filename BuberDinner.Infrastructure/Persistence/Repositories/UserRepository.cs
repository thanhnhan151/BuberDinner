using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.User;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];

    public void AddAsync(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmailAsync(string email)
    {
        return _users.SingleOrDefault(u => u.Email.Equals(email));
    }
}
