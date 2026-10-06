using System.Collections;

namespace lab7;

public class UserLinkedList<T> : IEnumerable
{
    public UserLinkedListNode<T>? Head;
    public UserLinkedListNode<T>? Tail;

    public UserLinkedListNode<T> AddFirst(T value)
    {
        var node = new UserLinkedListNode<T>(value);
        node.next = Head;

        if (Head != null)
        {
            Head.prev = node;
        }
        else
        {
            Tail = node;
        }

        Head = node;
        return node;
    }

    public UserLinkedListNode<T> AddLast(T value)
    {
        var node = new UserLinkedListNode<T>(value);
        node.prev = Tail;

        if (Tail != null)
        {
            Tail.next = node;
        }
        else
        {
            Head = node;
        }

        Tail = node;
        return node;
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }

    public UserLinkedListNode<T>? Find(T value)
    {
        var current = Head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(
                    current.Value, value))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    public UserLinkedListNode<T>? FindLast(T value)
    {
        var current = Tail;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(
                    current.Value, value))
            {
                return current;
            }

            current = current.Prev;
        }

        return null;
    }

    public void Remove(T value)
    {
        var node = Find(value);

        if (node == null)
        {
            return;
        }

        if (node.prev != null)
        {
            node.prev.next = node.next;
        }
        else
        {
            Head = node.next;
        }

        if (node.next != null)
        {
            node.next.prev = node.prev;
        }
        else
        {
            Tail = node.prev;
        }
    }

    public void RemoveFirst()
    {
        if (Head == null)
        {
            return;
        }

        Head = Head.next;

        if (Head != null)
        {
            Head.prev = null;
        }
        else
        {
            Tail = null;
        }
    }

    public void RemoveLast()
    {
        if (Tail == null)
        {
            return;
        }

        Tail = Tail.prev;

        if (Tail != null)
        {
            Tail.next = null;
        }
        else
        {
            Head = null;
        }
    }

    public IEnumerator GetEnumerator()
    {
        var current = Head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
}