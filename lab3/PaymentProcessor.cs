namespace lab3;

public class PaymentProcessor
{
    public void ProcessPayment(PaymentAccount account, decimal amount)
    {
        account.Pay(amount);
    }
}