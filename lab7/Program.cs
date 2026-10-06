using System.Collections;

namespace lab7;

public class Program
{
    public static void Main(string[] args)
    {
        var linkedList = new UserLinkedList<int>();

        linkedList.AddFirst(10);
        linkedList.AddLast(20);
        linkedList.AddLast(30);

        PrintList(linkedList);

        Console.WriteLine(
            "Contains 20: " + linkedList.Contains(20));

        var result = linkedList.Find(30);

        if (result is null)
        {
            Console.WriteLine("No element found");
        }
        else
        {
            Console.WriteLine("Found element: " + result.Value);
        }

        linkedList.RemoveFirst();
        linkedList.RemoveLast();

        PrintList(linkedList);
    }

    public static void PrintList(IEnumerable list)
    {
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}