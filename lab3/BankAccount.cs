namespace lab3;

public class BankAccount : PaymentAccount
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Paying with Bank Account: {amount}");
    }
}