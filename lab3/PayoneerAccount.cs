namespace lab3;

public class PayoneerAccount : PaymentAccount
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Paying with Payoneer Account: {amount}");
    }
}