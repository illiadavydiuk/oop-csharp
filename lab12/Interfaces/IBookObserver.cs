using lab12.Domain;

namespace lab12.Interfaces;

public interface IBookObserver
{
    void OnBookAdded(Book book);
    void OnBookUpdated(Book book);
}