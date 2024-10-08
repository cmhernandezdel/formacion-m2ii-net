namespace Tarradellas.Domain;

public sealed class Ingredient : Entity
{
    public string Name { get; private set; }

    public double Price { get; private set; }

    public Ingredient(string name, double price)
    {
        Name = name;
        Price = price;
    }
}
