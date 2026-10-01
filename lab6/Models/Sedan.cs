namespace lab6.Models;

public class Sedan : Car
{
    public int Doors { get; }

    public Sedan(
        string brand,
        string model,
        int year,
        decimal price,
        int doors)
        : base(brand, model, year, price)
    {
        Doors = doors;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, doors: {Doors}";
    }
}