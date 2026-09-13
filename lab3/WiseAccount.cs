namespace lab3;

public class WiseAccount : PaymentAccount
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Paying with Wise Account: {amount}");
    }
}