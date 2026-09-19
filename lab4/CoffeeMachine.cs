namespace lab4;

public class CoffeeMachine : ICoffeeMachine
{
    private int _water;
    private int _coffeeBeans;
    private bool _isWaterHeated;
    
    public int Water => _water;
    public int CoffeeBeans => _coffeeBeans;
    public bool IsWaterHeated => _isWaterHeated;

    public CoffeeMachine(int water, int coffeeBeans, bool isWaterHeated)
    {
        _water = water;
        _coffeeBeans = coffeeBeans;
        _isWaterHeated = isWaterHeated;
    }
    
    private void HeatWater(int amount)
    {
        Console.WriteLine("Нагріваємо воду...");
        _water -= amount;
        _isWaterHeated = true;
    }

    private bool GrindBeans(int amount)
    {
        if (amount > _coffeeBeans)
        {
            Console.WriteLine("Недостатньо кавових зерен");
            return false;
        }

        Console.WriteLine($"Мелемо {amount} г зерен...");
        _coffeeBeans -= amount;
        return true;
    }

    private bool HasEnoughWater(int amount)
    {
        if (amount > _water)
        {
            Console.WriteLine("Недостатньо води");
            return false;
        }
        
        return true;
    }

    public void MakeEspresso()
    {
        if (!HasEnoughWater(30)) return;
        if (!GrindBeans(20)) return;
        
        Console.WriteLine("Робимо еспресо...");
        
        HeatWater(30);

        Console.WriteLine("Ваше еспресо готове!");
    }
    
    public void MakeLatte()
    {
        if (!HasEnoughWater(40)) return;
        if (!GrindBeans(25)) return;
        
        Console.WriteLine("Робимо лате...");
        
        HeatWater(40);

        Console.WriteLine("Ваше лате готове!");
    }
}