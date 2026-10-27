using lab12.Interfaces;

namespace lab12.UI;


public class UserMenu
{

    private readonly IUserService _userService;
    private readonly SubscriptionMenu _subscriptionMenu;

    public UserMenu(
        IUserService userService,
        SubscriptionMenu subscriptionMenu)
    {
        _userService = userService;
        _subscriptionMenu = subscriptionMenu;
    }


    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n===== КОРИСТУВАЧІ =====");
            Console.WriteLine("1. Показати всіх користувачів");
            Console.WriteLine("2. Зареєструвати користувача");
            Console.WriteLine("3. Редагувати користувача");
            Console.WriteLine("4. Видалити користувача");
            Console.WriteLine("5. Керування підписками");
            Console.WriteLine("0. Назад");

            int choice = ReadInt("Ваш вибір: ");

            switch (choice)
            {
                case 1:
                    ShowUsers();
                    break;

                case 2:
                    string name = ReadRequiredString("Ім'я: ");
                    string email = ReadRequiredString("Email: ");

                    _userService.Add(name, email);
                    Console.WriteLine("Користувача зареєстровано.");
                    break;

                case 3:
                    int updateId = ReadInt("ID користувача: ");
                    string newName = ReadRequiredString("Нове ім'я: ");
                    string newEmail = ReadRequiredString("Новий email: ");

                    Console.WriteLine(
                        _userService.Update(updateId, newName, newEmail)
                            ? "Дані користувача оновлено."
                            : "Користувача не знайдено.");

                    break;

                case 4:
                    int deleteId = ReadInt("ID користувача: ");

                    Console.WriteLine(
                        _userService.Delete(deleteId)
                            ? "Користувача видалено."
                            : "Користувача не знайдено.");

                    break;

                case 5:
                    _subscriptionMenu.Run();
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Невірний пункт меню.");
                    break;
            }
        }
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
            string subscriptions =
                user.SubscribedCategories.Count == 0
                    ? "немає"
                    : string.Join(", ", user.SubscribedCategories);

            Console.WriteLine(
                $"ID: {user.Id} | Ім'я: {user.Name} | " +
                $"Email: {user.Email} | Підписки: {subscriptions}");
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
