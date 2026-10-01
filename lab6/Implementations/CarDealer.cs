using lab6.Interfaces;
using lab6.Models;

namespace lab6.Implementations;

public class CarDealer : ICarDealer
{
    private const decimal CustomerPriceMultiplier = 1.15m;

    private readonly IInventory _inventory;
    private readonly IAccount _account;

    public string DealerName { get; }

    public CarDealer(
        string dealerName,
        IInventory inventory,
        IAccount account)
    {
        DealerName = dealerName;
        _inventory = inventory;
        _account = account;
    }

    public IReadOnlyList<Car> GetAllCarsCustomer()
    {
        return _inventory.GetCars()
            .Select(CreateCustomerCar)
            .ToList();
    }

    public IReadOnlyList<Car> GetAllCarsAdmin()
    {
        return _inventory.GetCars();
    }

    public Car? GetCar(string brand, string model)
    {
        return _inventory.GetCars()
            .FirstOrDefault(car =>
                car.Brand.Equals(
                    brand,
                    StringComparison.OrdinalIgnoreCase) &&
                car.Model.Equals(
                    model,
                    StringComparison.OrdinalIgnoreCase));
    }

    public decimal GetBalance()
    {
        return _account.GetBalance();
    }

    public void BuyCarCustomer(Car car)
    {
        Car? existingCar = GetCar(
            car.Brand,
            car.Model);

        if (existingCar is null)
        {
            throw new InvalidOperationException(
                "Car is not available.");
        }

        decimal customerPrice =
            car.Price * CustomerPriceMultiplier;

        _account.Deposit(customerPrice);
        _inventory.RemoveCar(existingCar);
    }

    public void BuyCarDealer(Car car)
    {
        if (!_account.Withdraw(car.Price))
        {
            throw new InvalidOperationException(
                "Not enough money to buy the car.");
        }

        _inventory.AddCar(car);
    }

    public void SellCar(Car car)
    {
        if (!_inventory.GetCars().Contains(car))
        {
            throw new InvalidOperationException(
                "Car is not in dealer inventory.");
        }

        _inventory.RemoveCar(car);
        _account.Deposit(car.Price);
    }

    public void ExchangeCar(
        ICarDealer otherDealer,
        Car myCar,
        Car otherCar)
    {
        ValidateExchange(
            otherDealer,
            myCar,
            otherCar);

        BuyCarDealer(otherCar);
        SellCar(myCar);

        otherDealer.BuyCarDealer(myCar);
        otherDealer.SellCar(otherCar);
    }

    private void ValidateExchange(
        ICarDealer otherDealer,
        Car myCar,
        Car otherCar)
    {
        if (!_inventory.GetCars().Contains(myCar))
        {
            throw new InvalidOperationException(
                "Your car is not in dealer inventory.");
        }

        if (!otherDealer.GetAllCarsAdmin().Contains(otherCar))
        {
            throw new InvalidOperationException(
                "Other car is not in partner inventory.");
        }

        if (GetBalance() < otherCar.Price)
        {
            throw new InvalidOperationException(
                "Not enough money to buy other car.");
        }

        if (otherDealer.GetBalance() < myCar.Price)
        {
            throw new InvalidOperationException(
                "Partner dealer does not have enough money.");
        }
    }

    private static Car CreateCustomerCar(Car car)
    {
        decimal price =
            car.Price * CustomerPriceMultiplier;

        return car switch
        {
            Sedan sedan => new Sedan(
                sedan.Brand,
                sedan.Model,
                sedan.Year,
                price,
                sedan.Doors),

            SUV suv => new SUV(
                suv.Brand,
                suv.Model,
                suv.Year,
                price,
                suv.FourWheelDrive),

            _ => throw new InvalidOperationException(
                "Unknown car type.")
        };
    }
}