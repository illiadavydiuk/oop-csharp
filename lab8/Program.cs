var str = "a, 1, 2, f, -1, 0, 4, 10, 4,f, 4f, 8, 9, 3";

var sum = str
    .Split(',')
    .Select(x => x.Trim())
    .Where(x => int.TryParse(x, out _))
    .Select(int.Parse)
    .OrderBy(x => x)
    .Skip(3)
    .Sum();

Console.WriteLine(sum);    