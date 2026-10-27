using lab12.Domain;
using lab12.Interfaces;

namespace lab12.Observers;


public class CategoryEmailObserver : IBookObserver
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;

    public CategoryEmailObserver(
        IUserService userService,
        IEmailService emailService)
    {
        _userService = userService;
        _emailService = emailService;
    }

    public void OnBookAdded(Book book)
    {
        NotifySubscribers(book, "Додано нову книгу");
    }

    public void OnBookUpdated(Book book)
    {
        NotifySubscribers(book, "Оновлено книгу");
    }

    private void NotifySubscribers(Book book, string action)
    {
        var subscribers = _userService.GetAll()
            .Where(user =>
                user.SubscribedCategories.Contains(book.Category));

        foreach (var user in subscribers)
        {
            _emailService.SendEmail(
                user.Email,
                $"{action}: категорія {book.Category}",
                $"Книга \"{book.Title}\" автора {book.Author}."
            );
        }
    }
}
