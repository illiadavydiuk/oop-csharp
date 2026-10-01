using lab6.Interfaces;
using lab6.Models;

namespace lab6.Implementations;

public class Inventory : IInventory
{
    private readonly List<Car> _cars;

    public Inventory(List<Car> cars)
    {
        _cars = cars;
    }

    public IReadOnlyList<Car> GetCars()
    {
        return new List<Car>(_cars);
    }

    public void AddCar(Car car)
    {
        _cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        _cars.Remove(car);
    }
}