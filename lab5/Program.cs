using lab5;

Console.WriteLine("=== Digital Wallet ===");

// string login = "user@gmail.com";
// string password = "1234";

string login = "0987654321";
string password = "qwerty";

IDigitalWallet wallet = new DigitalWallet(
    1000,
    login,
    password);

// ILoginProvider authProvider = new GmailAuthProvider(login, password);
ILoginProvider authProvider = new Privat24AuthProvider("0987654321", "qwerty");

wallet.SetAuthProvider(authProvider);


while (true)
{
    Console.Write("\nLogin: ");
    string enteredLogin = Console.ReadLine() ?? "";

    Console.Write("Password: ");
    string enteredPassword = Console.ReadLine() ?? "";

    try
    {
        wallet.Authenticate(enteredLogin, enteredPassword);

        Console.WriteLine("Authentication successful!");
        break;
    }
    catch (UnauthorizedAccessException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Please try again.");
    }
}

while (true)
{
    Console.WriteLine("\n=== Menu ===");
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. Withdraw");
    Console.WriteLine("3. Check balance");
    Console.WriteLine("4. Transaction log");
    Console.WriteLine("0. Exit");

    Console.Write("Choose: ");
    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            Console.Write("Amount: ");

            if (decimal.TryParse(
                    Console.ReadLine(), out decimal depositAmount))
            {
                wallet.Deposit(depositAmount);
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }

            break;

        case "2":
            Console.Write("Amount: ");

            if (decimal.TryParse(
                    Console.ReadLine(), out decimal withdrawAmount))
            {
                wallet.Withdraw(withdrawAmount);
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }

            break;

        case "3":
            Console.WriteLine($"Balance: {wallet.CheckBalance()}");
            break;

        case "4":
            Console.WriteLine("\n=== Transaction log ===");

            List<string> transactions = wallet.GetTransactionLog();

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

        case "0":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid menu option.");
            break;
    }
}