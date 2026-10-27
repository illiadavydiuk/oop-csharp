using lab12.Domain;
using lab12.Interfaces;

namespace lab12.Services;


public class BookService : IBookService
{
    private readonly List<Book> _books = new();
    private readonly IEnumerable<IBookObserver> _observers;
    private int _nextId = 1;

    public BookService(IEnumerable<IBookObserver> observers)
    {
        _observers = observers;
    }

    public IReadOnlyList<Book> GetAll() => _books.AsReadOnly();

    public Book? GetById(int id) =>
        _books.FirstOrDefault(book => book.Id == id);

    public void Add(string title, string author, BookCategory category)
    {
        var book = new Book(_nextId++, title, author, category);
        _books.Add(book);

        foreach (var observer in _observers)
            observer.OnBookAdded(book);
    }

    public bool Update(
        int id,
        string title,
        string author,
        BookCategory category)
    {
        var book = GetById(id);

        if (book is null)
            return false;

        book.Update(title, author, category);

        foreach (var observer in _observers)
            observer.OnBookUpdated(book);

        return true;
    }

    public bool Delete(int id)
    {
        var book = GetById(id);

        if (book is null)
            return false;

        _books.Remove(book);
        return true;
    }
}
