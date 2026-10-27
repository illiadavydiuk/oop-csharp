using lab12.Domain;
using lab12.Interfaces;

namespace lab12.Services;


public class UserService : IUserService
{
    private readonly List<User> _users = new();
    private int _nextId = 1;

    public IReadOnlyList<User> GetAll()
    {
        return _users.AsReadOnly();
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public void Add(string name, string email)
    {
        var user = new User(_nextId++, name, email);
        _users.Add(user);
    }

    public bool Update(int id, string name, string email)
    {
        var user = GetById(id);

        if (user is null)
            return false;

        user.Update(name, email);

        return true;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);

        if (user is null)
            return false;

        _users.Remove(user);
        return true;
    }

    public bool Subscribe(int userId, BookCategory category)
    {
        var user = GetById(userId);

        if (user is null)
            return false;

        user.Subscribe(category);

        return true;
    }

    public bool Unsubscribe(int userId, BookCategory category)
    {
        var user = GetById(userId);

        if (user is null)
            return false;

        user.Unsubscribe(category);
        return true;
    }
}