using lab12.Interfaces;

namespace lab12.Services;

public class FileEmailService : IEmailService
{
    public void SendEmail(string email, string subject, string message)
    {
        string text =
            $"Кому: {email}\n" +
            $"Тема: {subject}\n" +
            $"Повідомлення: {message}\n\n";

        File.AppendAllText("emails.txt", text);
    }
}