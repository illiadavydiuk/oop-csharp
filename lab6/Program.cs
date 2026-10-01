using lab6.Interfaces;
using lab6.Wrappers;

namespace lab6;

public class Program
{
    public static void Main(string[] args)
    {
        List<ICarDealer> carDealers =
            AppInitializer.CreateDealers();

        Console.WriteLine(
            "Welcome to Car Dealer!");

        ChooseAccountType(carDealers);
    }

    private static void ChooseAccountType(
        List<ICarDealer> carDealers)
    {
        while (true)
        {
            Console.Write(
                "\nChoose account type " +
                "(admin, customer, exit): ");

            string input =
                Console.ReadLine() ?? "";

            switch (input.ToLower().Trim())
            {
                case "admin":
                    new AdminWrapper(carDealers).Run();
                    break;

                case "customer":
                    new CustomerWrapper(carDealers).Run();
                    break;

                case "exit":
                    return;

                default:
                    Console.WriteLine(
                        "Unknown account type.");
                    break;
            }
        }
    }
}