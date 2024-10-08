namespace Tarradellas.Domain;

public sealed class Pizza : Entity
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    public Uri Url { get; private set; }

    public IEnumerable<Ingredient> Ingredients { get; }

    public double GetPrice() => Ingredients.Sum(i => i.Price) * 1.2;

    public Pizza(string name, string description, Uri url, IEnumerable<Ingredient> ingredients)
    {
        Name = name;
        Description = description;
        Url = url;
        Ingredients = ingredients;
    }
}
