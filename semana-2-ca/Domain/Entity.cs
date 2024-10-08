namespace Tarradellas.Domain;

public abstract class Entity
{
    public Guid Id { get; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public override bool Equals(object? obj) => obj is Entity other && other.Id == Id;
    
    public override int GetHashCode() => Id.GetHashCode();
}
