using lab12.Domain;
using lab12.Interfaces;

namespace lab12.UI;

public class SubscriptionMenu
{
    private readonly IUserService _userService;

    public SubscriptionMenu(IUserService userService)
    {
        _userService = userService;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n===== ПІДПИСКИ =====");
            Console.WriteLine("1. Підписатися на категорію");
            Console.WriteLine("2. Відписатися від категорії");
            Console.WriteLine("0. Назад");

            int choice = ReadInt("Ваш вибір: ");

            switch (choice)
            {
                case 1:
                    ChangeSubscription(true);
                    break;

                case 2:
                    ChangeSubscription(false);
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Невірний пункт меню.");
                    break;
            }
        }
    }

    private void ChangeSubscription(bool subscribe)
    {
        ShowUsers();

        int userId = ReadInt("ID користувача: ");

        if (_userService.GetById(userId) is null)
        {
            Console.WriteLine("Користувача не знайдено.");
            return;
        }

        BookCategory category = ReadCategory();

        bool success = subscribe
            ? _userService.Subscribe(userId, category)
            : _userService.Unsubscribe(userId, category);

        Console.WriteLine(
            success
                ? subscribe
                    ? "Підписку оформлено."
                    : "Підписку скасовано."
                : "Не вдалося змінити підписку.");
    }

    private void ShowUsers()
    {
        var users = _userService.GetAll();

        if (users.Count == 0)
        {
            Console.WriteLine("Користувачів немає.");
            return;
        }

        foreach (var user in users)
        {
            Console.WriteLine(
                $"ID: {user.Id} | Ім'я: {user.Name} | " +
                $"Email: {user.Email}");
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
}
