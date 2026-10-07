using lab9;

int[] numbers = { 5, 2, 8, 1, 3 };

var sorter = new BubbleSorter();

sorter.Sort(numbers, (a, b) => a > b);

Console.WriteLine(string.Join(", ", numbers));