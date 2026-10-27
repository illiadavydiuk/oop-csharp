using lab12.Interfaces;

namespace lab12.Services;

public class ConsoleEmailService : IEmailService
{
    public void SendEmail(string email, string subject, string message)
    {
        Console.WriteLine("\n========== EMAIL ==========");
        Console.WriteLine($"Кому: {email}");
        Console.WriteLine($"Тема: {subject}");
        Console.WriteLine($"Повідомлення: {message}");
        Console.WriteLine("===========================\n");
    }
}