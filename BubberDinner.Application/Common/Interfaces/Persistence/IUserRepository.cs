using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetByEmail(string email);
    void AddUser(User user);
}