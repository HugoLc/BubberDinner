using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    //Por ser static anula o comportamento do AddScoped
    //com relação a recriar a lista a cada requisição.
    //Usando static a variavel pertence a classe e nao ao objeto
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