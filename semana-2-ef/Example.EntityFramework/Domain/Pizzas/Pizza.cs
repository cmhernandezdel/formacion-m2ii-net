using Example.EntityFramework.Domain.Core;
using Example.EntityFramework.Domain.Ingredients;

namespace Example.EntityFramework.Domain.Pizzas;

public sealed class Pizza : Entity
{
    private readonly HashSet<Ingredient> _ingredients;

    public string Name { get; private set; }

    public string Description { get; private set; }

    public Uri Url { get; private set; }

    public IReadOnlyCollection<Ingredient> Ingredients => _ingredients;

    public double GetPrice() => Ingredients.Sum(i => i.Price) * 1.2;

    private Pizza() : base(Guid.NewGuid())
    {
        // Entity Framework
    }

    private Pizza(Guid id, string name, string description, Uri url, HashSet<Ingredient> ingredients) : base(id)
    {
        Name = name;
        Description = description;
        Url = url;
        _ingredients = ingredients;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        _ingredients.Remove(ingredient);
    }

    public void Update (string name, string description, Uri url) 
    {
        Name = name;
        Description = description;
        Url = url;
    }

    public static Pizza Create(string name, string description, Uri url, HashSet<Ingredient> ingredients)
    {
        return new Pizza(Guid.NewGuid(), name, description, url, ingredients);
    }
}