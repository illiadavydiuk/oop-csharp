namespace lab1;

public class CurrentAccount : BankAccount
{
    private decimal _creditLimit;

    public CurrentAccount(
        string accountNumber,
        string owner,
        decimal balance)
        : base(accountNumber, owner, balance)
    {
        _creditLimit = 0;
    }

    public override void ShowBalance()
    {
        Console.WriteLine($"\nБаланс: {Balance}");
        Console.WriteLine($"Кредитний ліміт: {_creditLimit}");
        Console.WriteLine($"Всього доступно: {Balance + _creditLimit}\n");
    }

    public override void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сума поповнення має бути більша за 0");
            return;
        }
        
        Balance += amount;
        Console.WriteLine($"Рахунок поповнено на {amount} грн");
    }

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сума зняття має бути більшою за 0");
            return;
        }

        if (amount > Balance + _creditLimit)
        {
            Console.WriteLine("Перевищено доступний баланс і кредитний ліміт");
            return;
        } 
        
        Balance -= amount;
        Console.WriteLine($"Знято {amount} грн.");
    }

    public void SetCreditLimit(decimal creditLimit)
    {
        if (creditLimit < 0)
        {
            Console.WriteLine("Кредитний ліміт не може бути від'ємним");
            return;
        }
        _creditLimit = creditLimit;
        Console.WriteLine($"Кредитний ліміт встановлено в розмірі {_creditLimit} грн.");
    }
}