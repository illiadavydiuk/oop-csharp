namespace lab2;

public class Dog : Animal
{
    public override void Walk()
    {
        Console.WriteLine("Собака бігає");
    }
    public override void Sound()
    {
        Console.WriteLine("Гав");
    }
}