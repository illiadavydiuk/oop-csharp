namespace lab5;

public class DigitalWallet : IDigitalWallet
{
    private decimal _balance;
    private readonly string _login;
    private readonly string _hashedPassword;
    private readonly List<string> _transactions = [];
    
    private ILoginProvider? _authProvider;
    private bool _isAuthenticated;


    public DigitalWallet(decimal balance, string login, string password)
    {
        _balance = balance;
        _login = login;
        _hashedPassword = PasswordHasher.Hash(password);
    }

    public void SetAuthProvider(ILoginProvider provider)
    {
        _authProvider = provider;
    }
    
    public void Authenticate(string login, string password)
    {
        if (_authProvider == null ||
            !_authProvider.Validate(login, password))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }
        
        // if (login != _login || 
        //     PasswordHasher.Hash(password) != _hashedPassword)
        // {
        //     throw new UnauthorizedAccessException("Invalid credentials");
        // }
        
        _isAuthenticated = true;
    }

    private void CheckAuthentication()
    {
        if (!_isAuthenticated) throw new UnauthorizedAccessException("Invalid credentials");
    }
    
    public void Deposit(decimal amount)
    {
        CheckAuthentication();

        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount");
            return;
        }
        
        _balance += amount;
        _transactions.Add($"Deposit: +{amount}");
        Console.WriteLine($"Current balance: {_balance}");
    }

    public void Withdraw(decimal amount)
    {
        CheckAuthentication();

        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount");
            return;
        }
        
        if (amount > _balance)
        {
            Console.WriteLine("Insufficient funds");
            return;
        }
        
        _balance -= amount;
        _transactions.Add($"Withdraw: -{amount}");
        Console.WriteLine($"Current balance: {_balance}");
    }

    public decimal CheckBalance()
    {
        CheckAuthentication();
        return _balance;
    }

    public List<string> GetTransactionLog()
    {
        CheckAuthentication();
        return new List<string>(_transactions);
    }
}