namespace lab12.Interfaces;

public interface IEmailService
{
    void SendEmail(string email, string subject, string message);
}