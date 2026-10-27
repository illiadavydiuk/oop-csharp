namespace lab12.UI;


public class LibraryMenu
{
    private readonly UserMenu _userMenu;
    private readonly BookMenu _bookMenu;

    public LibraryMenu(UserMenu userMenu, BookMenu bookMenu)
    {
        _userMenu = userMenu;
        _bookMenu = bookMenu;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n===== БІБЛІОТЕКА =====");
            Console.WriteLine("1. Користувачі");
            Console.WriteLine("2. Книги");
            Console.WriteLine("0. Вихід");

            Console.Write("Ваш вибір: ");

            switch (Console.ReadLine())
            {
                case "1":
                    _userMenu.Run();
                    break;

                case "2":
                    _bookMenu.Run();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Невірний пункт меню.");
                    break;
            }
        }
    }
}