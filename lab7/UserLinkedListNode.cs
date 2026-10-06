namespace lab7;

public class UserLinkedListNode<T>
{
    private T _data;

    internal UserLinkedListNode<T>? next;
    internal UserLinkedListNode<T>? prev;

    public UserLinkedListNode(T value)
    {
        _data = value;
    }

    public T Value
    {
        get => _data;
        set => _data = value;
    }
    
    public UserLinkedListNode<T>? Next => next;
    public UserLinkedListNode<T>? Prev => prev;
}