using lab6.Interfaces;
using lab6.Models;

namespace lab6.Wrappers;

public class CustomerWrapper
{
    private readonly List<ICarDealer> _carDealers;

    public CustomerWrapper(List<ICarDealer> carDealers)
    {
        _carDealers = carDealers;
    }

    public void Run()
    {
        while (true)
        {
            Console.Write(
                "Choose car dealership " +
                "(toyota, bmw, audi, back): ");

            string input = Console.ReadLine() ?? "";

            switch (input.ToLower().Trim())
            {
                case "toyota":
                    CustomerMenu(GetDealer("Toyota"));
                    break;

                case "bmw":
                    CustomerMenu(GetDealer("BMW"));
                    break;

                case "audi":
                    CustomerMenu(GetDealer("Audi"));
                    break;

                case "back":
                    return;
            }
        }
    }

    private void CustomerMenu(ICarDealer carDealer)
    {
        while (true)
        {
            Console.Write(
                "\nChoose your action:\n" +
                "1 - List cars\n" +
                "2 - Buy car\n" +
                "0 - Back\n" +
                "Action: ");

            string input = Console.ReadLine() ?? "";

            switch (input.Trim())
            {
                case "1":
                    ListCars(
                        carDealer.GetAllCarsCustomer());
                    break;

                case "2":
                    BuyCar(carDealer);
                    break;

                case "0":
                    return;
            }
        }
    }

    private void BuyCar(ICarDealer carDealer)
    {
        Console.Write("Enter car's brand: ");
        string brand = Console.ReadLine() ?? "";

        Console.Write("Enter car's model: ");
        string model = Console.ReadLine() ?? "";

        Car? car = carDealer.GetCar(
            brand,
            model);

        if (car is null)
        {
            Console.WriteLine(
                "Couldn't find car.");

            return;
        }

        try
        {
            carDealer.BuyCarCustomer(car);

            Console.WriteLine(
                $"{car.Brand} {car.Model} " +
                "has been successfully bought.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ListCars(
        IReadOnlyList<Car> cars)
    {
        for (int i = 0; i < cars.Count; i++)
        {
            Console.WriteLine(
                $"{i}. {cars[i]}");
        }
    }

    private ICarDealer GetDealer(string name)
    {
        return _carDealers.First(
            dealer => dealer.DealerName.Equals(
                name,
                StringComparison.OrdinalIgnoreCase));
    }
}