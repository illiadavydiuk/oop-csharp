using lab2;

Snake snake = new Snake();
Console.WriteLine("===Snake===");
snake.Sound();
snake.Walk();

Console.WriteLine("\n===Dog===");
Dog dog = new Dog();
dog.Sound();
dog.Walk();

Console.WriteLine("\n===Cat===");
Cat cat = new Cat();
cat.Sound();
cat.Walk();