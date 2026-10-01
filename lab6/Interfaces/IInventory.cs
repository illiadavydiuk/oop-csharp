using lab6.Models;

namespace lab6.Interfaces;

public interface IInventory
{
    IReadOnlyList<Car> GetCars();

    void AddCar(Car car);

    void RemoveCar(Car car);
}