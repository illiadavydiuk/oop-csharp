namespace lab1;

public class DepositAccount : BankAccount
{
    private decimal _interestRate;

    public DepositAccount(
        string accountNumber,
        string owner,
        decimal balance,
        decimal interestRate)
        : base(accountNumber, owner, balance)
    {
        _interestRate = interestRate;
    }
    
    public override void ShowBalance()
    {
        Console.WriteLine($"\nДепозитний рахунок {AccountNumber}: баланс = {Balance} грн\n");
    }
    
    public override void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сума поповнення має бути більша 0");
            return;
        }
        
        Balance += amount;
        Console.WriteLine($"Рахунок поповнено на {amount} грн.");
    }
    
    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сума зняття повина бути більшою за 0");
            return;
        }
        
        if (Balance < amount)
        {
            Console.WriteLine("Недостатньо коштів на рахунку");
            return;
        }
        
        Balance -= amount;
        Console.WriteLine($"З рахунку знято {amount} грн.");
    }
    
    public void CalculateInterest()
    {
        decimal interest = Balance * _interestRate / 100;
        Balance += interest;
        
        Console.WriteLine($"Нараховано відсотки: {interest} грн \n" +
                          $"Загальний баланс: {Balance}");
    }
    
}