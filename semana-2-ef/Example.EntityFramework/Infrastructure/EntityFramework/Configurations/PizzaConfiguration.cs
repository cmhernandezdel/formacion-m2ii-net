using Example.EntityFramework.Domain.Pizzas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.EntityFramework.Infrastructure.EntityFramework.Configurations;

public sealed class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Ingredients)
            .WithMany()
            .UsingEntity("PizzasIngredientsJoinTable");
        
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Url).IsRequired();
    }
}
