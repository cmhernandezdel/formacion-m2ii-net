using Example.EntityFramework.Domain.Core;
using Example.EntityFramework.Domain.Ingredients;
using Example.EntityFramework.Domain.Pizzas;
using Example.EntityFramework.Infrastructure.EntityFramework.Configurations;
using Example.EntityFramework.Infrastructure.EntityFramework.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Example.EntityFramework.Infrastructure.EntityFramework;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors(new LoggingInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new IngredientConfiguration());
        modelBuilder.ApplyConfiguration(new PizzaConfiguration());
    }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<OutboxEvent> OutboxEvents { get; set; }
}
