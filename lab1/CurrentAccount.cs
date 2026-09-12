namespace lab1;

public class CurrentAccount : BankAccount
{
    public decimal CreditLimit { get; private set; }

    public CurrentAccount(
        string accountNumber,
        string owner,
        decimal balance)
        : base(accountNumber, owner, balance)
    {
        CreditLimit = 0;
    }

    public override void ShowBalance()
    {
        Console.WriteLine($"\nБаланс: {Balance}");
        Console.WriteLine($"Кредитний ліміт: {CreditLimit}");
        Console.WriteLine($"Всього доступно: {Balance + CreditLimit}\n");
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

        if (amount > Balance + CreditLimit)
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
        CreditLimit = creditLimit;
        Console.WriteLine($"Кредитний ліміт встановлено в розмірі {CreditLimit} грн.");
    }
}