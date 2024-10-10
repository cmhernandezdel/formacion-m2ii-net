using Example.EntityFramework.Domain.Ingredients;
using Example.EntityFramework.Domain.Pizzas;
using Example.EntityFramework.Infrastructure.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Example.EntityFramework.Infrastructure.EntityFramework;

public sealed class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new IngredientConfiguration());
        modelBuilder.ApplyConfiguration(new PizzaConfiguration());
    }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
}
