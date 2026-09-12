namespace lab1;

public abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public string Owner { get; set; }
    public decimal Balance { get; protected set; }

    protected BankAccount(string accountNumber, string owner, decimal balance)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        Balance = balance;
    }
    
    public abstract void ShowBalance();
    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}