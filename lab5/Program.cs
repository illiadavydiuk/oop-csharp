using lab5;

List<IDigitalWallet> wallets = CreateWallets();

while (true)
{
    IDigitalWallet currentWallet = AuthenticateUser(wallets);

    bool isRunning = true;

    while (isRunning)
    {
        ShowMenu();

        Console.Write("Choose: ");
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                WalletWrapper.Deposit(currentWallet);
                break;

            case "2":
                WalletWrapper.Withdraw(currentWallet);
                break;

            case "3":
                WalletWrapper.CheckBalance(currentWallet);
                break;

            case "4":
                WalletWrapper.GetTransactionLog(currentWallet);
                break;

            case "5":
                Console.WriteLine("Logging out...");
                isRunning = false;
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


static List<IDigitalWallet> CreateWallets()
{
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

    return wallets;
}


static IDigitalWallet AuthenticateUser(
    List<IDigitalWallet> wallets)
{
    while (true)
    {
        Console.Write("\nLogin: ");
        string enteredLogin = Console.ReadLine() ?? "";

        Console.Write("Password: ");
        string enteredPassword = Console.ReadLine() ?? "";
        string? errorM = null;
        foreach (IDigitalWallet wallet in wallets)
        {
            try
            {
                wallet.Authenticate(
                    enteredLogin,
                    enteredPassword);

                return wallet;
            }
            catch (UnauthorizedAccessException ex)
            {
                errorM = ex.Message;
            }
        }

        Console.WriteLine(errorM);
    }
}


static void ShowMenu()
{
    Console.WriteLine("\n=== Menu ===");
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. Withdraw");
    Console.WriteLine("3. Check balance");
    Console.WriteLine("4. Transaction log");
    Console.WriteLine("5. Logout");
    Console.WriteLine("0. Exit");
}
