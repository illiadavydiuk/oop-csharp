namespace lab4;

public interface ICoffeeMachine
{
    int Water { get; }
    int CoffeeBeans { get; }
    bool IsWaterHeated { get; }
    
    void MakeEspresso();
    void MakeLatte();
}