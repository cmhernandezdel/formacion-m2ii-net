using Example.EntityFramework.Domain.Core;

namespace Example.EntityFramework.Domain.Ingredients;

public sealed class Ingredient : Entity
{
    public string Name { get; private set; }

    public double Price { get; private set; }

    private Ingredient(Guid id, string name, double price) : base(id)
    {
        Name = name;
        Price = price;
    }

    public void Update(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public static Ingredient Create(string name, double price)
    {
        return new Ingredient(Guid.NewGuid(), name, price);
    }
}