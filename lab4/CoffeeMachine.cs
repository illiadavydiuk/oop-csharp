namespace lab4;

public class CoffeeMachine : ICoffeeMachine
{
    private int water;
    private int coffeeBeans;
    private bool isWaterHeated;
    
    public int Water => water;
    public int CoffeeBeans => coffeeBeans;
    public bool IsWaterHeated => isWaterHeated;

    public CoffeeMachine(int water, int coffeeBeans, bool isWaterHeated)
    {
        this.water = water;
        this.coffeeBeans = coffeeBeans;
        this.isWaterHeated = false;
    }
    
    private void HeatWater(int amount)
    {
        Console.WriteLine("Нагріваємо воду...");
        water -= amount;
        isWaterHeated = true;
    }

    private bool GrindBeans(int amount)
    {
        if (amount > coffeeBeans)
        {
            Console.WriteLine("Недостатньо кавових зерен");
            return false;
        }

        Console.WriteLine($"Мелемо {amount} г зерен...");
        coffeeBeans -= amount;
        return true;
    }

    private bool HasEnoughWater(int amount)
    {
        if (amount > water)
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