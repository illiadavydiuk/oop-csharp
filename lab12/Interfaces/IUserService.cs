using lab12.Domain;

namespace lab12.Interfaces;

public interface IUserService
{
    IReadOnlyList<User> GetAll();

    User? GetById(int id);

    void Add(string name, string email);

    bool Update(int id, string name, string email);

    bool Delete(int id);

    bool Subscribe(int userId, BookCategory category);

    bool Unsubscribe(int userId, BookCategory category);
}