namespace lab12.Domain;

public class User
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    private readonly List<BookCategory> _subscribedCategories = new();

    public IReadOnlyCollection<BookCategory> SubscribedCategories =>
        _subscribedCategories.AsReadOnly();

    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void Subscribe(BookCategory category)
    {
        if (!_subscribedCategories.Contains(category))
            _subscribedCategories.Add(category);
    }

    public void Unsubscribe(BookCategory category)
    {
        _subscribedCategories.Remove(category);
    }
}