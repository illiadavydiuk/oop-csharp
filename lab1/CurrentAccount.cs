namespace lab1;

public class CurrentAccount : BankAccount
{
    public decimal CreditLimit { get; set; }

    public CurrentAccount(
        string accountNumber,
        string owner,
        decimal balance,
        decimal creditLimit)
        : base(accountNumber, owner, balance)
    {
        CreditLimit = 0;
    }

    public override void ShowBalance()
    {
        
    }

    public override void Deposit(decimal amount)
    {
        
    }

    public override void Withdraw(decimal amount)
    {
        
    }

    public void SetCreditLimit(decimal creditLimit)
    {
        
    }
}