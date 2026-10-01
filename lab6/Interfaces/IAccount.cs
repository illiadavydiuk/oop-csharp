namespace lab6.Interfaces;

public interface IAccount
{
    decimal GetBalance();

    void Deposit(decimal amount);

    bool Withdraw(decimal amount);
}