namespace lab6.Models;

public class SUV : Car
{
    public bool FourWheelDrive { get; }

    public SUV(
        string brand,
        string model,
        int year,
        decimal price,
        bool fourWheelDrive)
        : base(brand, model, year, price)
    {
        FourWheelDrive = fourWheelDrive;
    }

    public override string ToString()
    {
        string drive = FourWheelDrive ? "4WD" : "2WD";

        return $"{base.ToString()}, {drive}";
    }
}