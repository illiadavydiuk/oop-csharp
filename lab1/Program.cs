using lab1;

DepositAccount depositAccount = new DepositAccount("123456789", "Illia", 1000, 2.5m);

Console.WriteLine("Депозитний рахунок");
depositAccount.ShowBalance();
depositAccount.Deposit(100);
depositAccount.Withdraw(50);
depositAccount.CalculateInterest();
depositAccount.ShowBalance();
Console.WriteLine("\n");

CurrentAccount currentAccount = new CurrentAccount("123", "Bogdan", 5000);

Console.WriteLine("Кредитний рахунок");
currentAccount.ShowBalance();
currentAccount.SetCreditLimit(10000);
currentAccount.Deposit(1000);
currentAccount.Withdraw(11000);
currentAccount.ShowBalance();
currentAccount.Withdraw(12000);

