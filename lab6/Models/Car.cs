namespace lab6.Models;

public abstract class Car
{
    public string Brand { get; }

    public string Model { get; }

    public int Year { get; }

    public decimal Price { get; }

    protected Car(
        string brand,
        string model,
        int year,
        decimal price)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Brand} {Model} - {Year}. ${Price}";
    }
}