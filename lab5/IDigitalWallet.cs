namespace lab5;

public interface IDigitalWallet
{
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    decimal CheckBalance();
    List<string> GetTransactionLog();
    
    void SetAuthProvider(ILoginProvider provider);
    void Authenticate(string login, string password);
}