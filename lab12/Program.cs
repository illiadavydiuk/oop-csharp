using lab12.Interfaces;
using lab12.Observers;
using lab12.Services;
using lab12.UI;
using Microsoft.Extensions.DependencyInjection;

namespace lab12;

public class Program
{
    public static void Main()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IEmailService, ConsoleEmailService>();
        // services.AddSingleton<IEmailService, FileEmailService>();
        
        services.AddSingleton<IBookObserver, CategoryEmailObserver>();
        services.AddSingleton<IBookService, BookService>();

        services.AddTransient<SubscriptionMenu>();
        services.AddTransient<UserMenu>();
        services.AddTransient<BookMenu>();
        services.AddTransient<LibraryMenu>();

        using var provider = services.BuildServiceProvider();

        var libraryMenu = provider.GetRequiredService<LibraryMenu>();
        libraryMenu.Run();
    }
}
