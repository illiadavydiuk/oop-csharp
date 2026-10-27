namespace lab12.Domain;

public class Book
{
    public int Id { get; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public BookCategory Category { get; private set; }

    public Book(int id, string title, string author, BookCategory category)
    {
        Id = id;
        Title = title;
        Author = author;
        Category = category;
    }
    
    public void Update(string title, string author, BookCategory category)
    {
        Title = title;
        Author = author;
        Category = category;
    }
}