
namespace example.domain;

public sealed class Book : Entity
{
    public string Name { get; }

    private Book(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public static Book Create(string name)
    {
        return new Book(Guid.NewGuid(), name);
    }
}
