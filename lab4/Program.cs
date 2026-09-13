using lab4;

ICoffeeMachine machine = new CoffeeMachine(200, 150, false);

Console.WriteLine("Вітаємо!!!");


while (true)
{
    Console.WriteLine();
    Console.WriteLine("Оберіть необхідний Вам пункт");
    Console.WriteLine("1 - Подивитися статистику");
    Console.WriteLine("2 - Приготувати еспресо");
    Console.WriteLine("3 - Приготувати лате");
    Console.WriteLine("4 - Вийти\n");
    Console.Write("Вибір: ");
    
    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("Кавомашина в чудовому стані!");
            Console.WriteLine($"Кількість води: {machine.Water} мл.");
            Console.WriteLine($"Кількість зерен: {machine.CoffeeBeans} г.");
            Console.WriteLine($"Чи нагріта вода: {machine.IsWaterHeated}");
            break;
        
        case "2":
            machine.MakeEspresso();
            break;
        
        case "3":
            machine.MakeLatte();
            break;
        
        case "4":
            Console.WriteLine("Завершення роботи кавомашини...");
            return;
        
        default:
            Console.WriteLine("Неіснуючий вибір.");
            break;
    }
}