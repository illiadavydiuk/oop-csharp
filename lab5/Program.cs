using lab5;

List<IDigitalWallet> wallets = new();

IDigitalWallet wallet1 = new DigitalWallet(
    1000,
    "0987654321",
    "qwerty");

wallet1.SetAuthProvider(
    new Privat24AuthProvider("0987654321", "qwerty"));

wallets.Add(wallet1);


IDigitalWallet wallet2 = new DigitalWallet(
    500,
    "user@gmail.com",
    "1234");

wallet2.SetAuthProvider(
    new GmailAuthProvider("user@gmail.com", "1234"));

wallets.Add(wallet2);


while (true)
{
    IDigitalWallet? currentWallet = null;
    
    while (currentWallet == null)
    {
        Console.Write("\nLogin: ");
        string enteredLogin = Console.ReadLine() ?? "";

        Console.Write("Password: ");
        string enteredPassword = Console.ReadLine() ?? "";

        foreach (IDigitalWallet wallet in wallets)
        {
            try
            {
                wallet.Authenticate(enteredLogin, enteredPassword);
                currentWallet = wallet;
                break;
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        if (currentWallet == null)
        {
            Console.WriteLine("Invalid credentials");
        }
    }
    
    while (currentWallet != null)
    {
        Console.WriteLine("\n=== Menu ===");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Check balance");
        Console.WriteLine("4. Transaction log");
        Console.WriteLine("5. Logout");
        Console.WriteLine("0. Exit");

        Console.Write("Choose: ");
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                Console.Write("Amount: ");

                if (decimal.TryParse(
                        Console.ReadLine(),
                        out decimal depositAmount))
                {
                    currentWallet.Deposit(depositAmount);
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }

                break;

            case "2":
                Console.Write("Amount: ");

                if (decimal.TryParse(
                        Console.ReadLine(),
                        out decimal withdrawAmount))
                {
                    currentWallet.Withdraw(withdrawAmount);
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }

                break;

            case "3":
                Console.WriteLine(
                    $"Balance: {currentWallet.CheckBalance()}");
                break;

            case "4":
                Console.WriteLine("\n=== Transaction log ===");

                List<string> transactions =
                    currentWallet.GetTransactionLog();

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

                break;

            case "5":
                Console.WriteLine("Logging out...");
                currentWallet = null;
                break;

            case "0":
                Console.WriteLine("Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid menu option.");
                break;
        }
    }
}
