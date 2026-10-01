using lab6.Interfaces;
using lab6.Models;

namespace lab6.Wrappers;

public class AdminWrapper
{
    private readonly List<ICarDealer> _carDealers;

    public AdminWrapper(List<ICarDealer> carDealers)
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
                    DealerMenu(GetDealer("Toyota"));
                    break;

                case "bmw":
                    DealerMenu(GetDealer("BMW"));
                    break;

                case "audi":
                    DealerMenu(GetDealer("Audi"));
                    break;

                case "back":
                    return;
            }
        }
    }

    private void DealerMenu(ICarDealer carDealer)
    {
        while (true)
        {
            Console.Write(
                "\nChoose your action:\n" +
                "1 - List cars\n" +
                "2 - List cars from other dealerships\n" +
                "3 - Sell car\n" +
                "4 - Exchange car\n" +
                "5 - Check balance\n" +
                "0 - Back\n" +
                "Action: ");

            string input = Console.ReadLine() ?? "";

            switch (input.Trim())
            {
                case "1":
                    ListCars(
                        carDealer.GetAllCarsAdmin());
                    break;

                case "2":
                    ListOtherCars(carDealer);
                    break;

                case "3":
                    SellCar(carDealer);
                    break;

                case "4":
                    ExchangeCar(carDealer);
                    break;

                case "5":
                    Console.WriteLine(
                        $"Balance: " +
                        $"{carDealer.GetBalance():C}");
                    break;

                case "0":
                    return;
            }
        }
    }

    private void ListOtherCars(ICarDealer carDealer)
    {
        IReadOnlyList<Car> cars = _carDealers
            .Where(dealer =>
                dealer.DealerName != carDealer.DealerName)
            .SelectMany(dealer =>
                dealer.GetAllCarsAdmin())
            .ToList();

        ListCars(cars);
    }

    private void SellCar(ICarDealer carDealer)
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
                "Could not find the car.");

            return;
        }

        try
        {
            carDealer.SellCar(car);

            Console.WriteLine(
                "Successfully sold car.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ExchangeCar(ICarDealer carDealer)
    {
        Console.Write(
            "Enter other dealership name: ");

        string dealerName =
            Console.ReadLine() ?? "";

        ICarDealer? otherDealer =
            _carDealers.FirstOrDefault(
                dealer => dealer.DealerName.Equals(
                    dealerName,
                    StringComparison.OrdinalIgnoreCase));

        if (otherDealer is null ||
            otherDealer == carDealer)
        {
            Console.WriteLine(
                "Could not find other dealership.");

            return;
        }

        Console.Write(
            "Enter your car brand: ");

        string myBrand =
            Console.ReadLine() ?? "";

        Console.Write(
            "Enter your car model: ");

        string myModel =
            Console.ReadLine() ?? "";

        Car? myCar = carDealer.GetCar(
            myBrand,
            myModel);

        if (myCar is null)
        {
            Console.WriteLine(
                "Your car was not found.");

            return;
        }

        Console.Write(
            "Enter other car brand: ");

        string otherBrand =
            Console.ReadLine() ?? "";

        Console.Write(
            "Enter other car model: ");

        string otherModel =
            Console.ReadLine() ?? "";

        Car? otherCar = otherDealer.GetCar(
            otherBrand,
            otherModel);

        if (otherCar is null)
        {
            Console.WriteLine(
                "Other car was not found.");

            return;
        }

        try
        {
            carDealer.ExchangeCar(
                otherDealer,
                myCar,
                otherCar);

            Console.WriteLine(
                "Cars were successfully exchanged.");
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