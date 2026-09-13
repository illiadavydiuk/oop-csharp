namespace lab2;

public class Cat : Animal
{
    public override void Walk()
    {
        Console.WriteLine("Кіт ходить");
    }

    public override void Sound()
    {
        Console.WriteLine("Мяу");
    }
}