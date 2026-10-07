namespace lab9;

public delegate bool Compare(int a, int b);

public class BubbleSorter
{
    public void Sort(int[] numbers, Compare compare)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - i - 1; j++)
            {
                if (compare(numbers[j], numbers[j + 1]))
                {
                    (numbers[j], numbers[j + 1]) =
                        (numbers[j + 1], numbers[j]);
                }
            }
        }
    }
}