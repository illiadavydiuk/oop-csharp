using lab5;

public static class WalletWrapper
{
    public static void Deposit(IDigitalWallet wallet)
    {
        Console.Write("Amount: ");

        if (decimal.TryParse(
                Console.ReadLine(),
                out decimal amount))
        {
            wallet.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }


    public static void Withdraw(IDigitalWallet wallet)
    {
        Console.Write("Amount: ");

        if (decimal.TryParse(
                Console.ReadLine(),
                out decimal amount))
        {
            wallet.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }


    public static void CheckBalance(IDigitalWallet wallet)
    {
        Console.WriteLine(
            $"Balance: {wallet.CheckBalance()}");
    }


    public static void GetTransactionLog(IDigitalWallet wallet)
    {
        Console.WriteLine("\n=== Transaction log ===");

        List<string> transactions =
            wallet.GetTransactionLog();

        if (transactions.Count == 0)
        {
            Console.WriteLine("No transactions yet.");
        }
        else
        {
            foreach (string transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}