using lab12.Domain;

namespace lab12.Interfaces;


public interface IBookService
{
    IReadOnlyList<Book> GetAll();

    Book? GetById(int id);

    void Add(string title, string author, BookCategory category);

    bool Update(int id, string title, string author, BookCategory category);

    bool Delete(int id);
}