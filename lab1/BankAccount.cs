namespace lab1;

public abstract class BankAccount
{
    protected string AccountNumber;
    protected string Owner;
    protected decimal Balance;

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