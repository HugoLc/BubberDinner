using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User? GetByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}