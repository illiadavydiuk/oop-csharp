using lab12.Domain;
using lab12.Interfaces;

namespace lab12.UI;


public class BookMenu
{
    private readonly IBookService _bookService;

    public BookMenu(IBookService bookService)
    {
        _bookService = bookService;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n===== КНИГИ =====");
            Console.WriteLine("1. Показати всі книги");
            Console.WriteLine("2. Додати книгу");
            Console.WriteLine("3. Редагувати книгу");
            Console.WriteLine("4. Видалити книгу");
            Console.WriteLine("0. Назад");

            int choice = ReadInt("Ваш вибір: ");

            switch (choice)
            {
                case 1:
                    ShowBooks();
                    break;

                case 2:
                {
                    string title = ReadRequiredString("Назва книги: ");
                    string author = ReadRequiredString("Автор: ");
                    BookCategory category = ReadCategory();

                    _bookService.Add(title, author, category);
                    Console.WriteLine("Книгу додано до каталогу.");
                    break;
                }

                case 3:
                {
                    int id = ReadInt("ID книги: ");
                    string title = ReadRequiredString("Нова назва: ");
                    string author = ReadRequiredString("Новий автор: ");
                    BookCategory category = ReadCategory();

                    Console.WriteLine(
                        _bookService.Update(id, title, author, category)
                            ? "Книгу оновлено."
                            : "Книгу не знайдено.");

                    break;
                }

                case 4:
                {
                    int id = ReadInt("ID книги: ");

                    Console.WriteLine(
                        _bookService.Delete(id)
                            ? "Книгу видалено."
                            : "Книгу не знайдено.");

                    break;
                }

                case 0:
                    return;

                default:
                    Console.WriteLine("Невірний пункт меню.");
                    break;
            }
        }
    }

    private void ShowBooks()
    {
        var books = _bookService.GetAll();

        if (books.Count == 0)
        {
            Console.WriteLine("Каталог порожній.");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine(
                $"ID: {book.Id} | Назва: {book.Title} | " +
                $"Автор: {book.Author} | Категорія: {book.Category}");
        }
    }

    private static BookCategory ReadCategory()
    {
        Console.WriteLine("\nКатегорії книг:");

        foreach (BookCategory category in Enum.GetValues<BookCategory>())
        {
            Console.WriteLine($"{(int)category}. {category}");
        }

        while (true)
        {
            int choice = ReadInt("Оберіть категорію: ");

            if (Enum.IsDefined(typeof(BookCategory), choice))
                return (BookCategory)choice;

            Console.WriteLine("Такої категорії немає.");
        }
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int result))
                return result;

            Console.WriteLine("Введіть ціле число.");
        }
    }

    private static string ReadRequiredString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            string? value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
                return value.Trim();

            Console.WriteLine("Поле не може бути порожнім.");
        }
    }
}
