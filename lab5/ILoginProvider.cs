namespace lab5;

public interface ILoginProvider
{
    bool Validate(string login, string password);
}