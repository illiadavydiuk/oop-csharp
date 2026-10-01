using lab6.Models;

namespace lab6.Interfaces;

public interface ICarDealer
{
    string DealerName { get; }

    IReadOnlyList<Car> GetAllCarsCustomer();

    IReadOnlyList<Car> GetAllCarsAdmin();

    Car? GetCar(string brand, string model);

    decimal GetBalance();

    void BuyCarCustomer(Car car);

    void BuyCarDealer(Car car);

    void SellCar(Car car);

    void ExchangeCar(
        ICarDealer otherDealer,
        Car myCar,
        Car otherCar);
}