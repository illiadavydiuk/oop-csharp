using lab6.Interfaces;

namespace lab6.Implementations;

public class CurrentAccount : IAccount
{
    private decimal _currentBalance;

    public CurrentAccount(decimal balance)
    {
        _currentBalance = balance;
    }

    public decimal GetBalance()
    {
        return _currentBalance;
    }

    public void Deposit(decimal amount)
    {
        _currentBalance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= _currentBalance)
        {
            _currentBalance -= amount;
            return true;
        }

        return false;
    }
}