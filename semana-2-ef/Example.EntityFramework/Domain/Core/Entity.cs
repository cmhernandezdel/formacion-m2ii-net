using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.EntityFramework.Domain.Core;

public abstract class Entity
{
    public Guid Id { get; }

    private Entity()
    {
        // Entity framework
    }

    protected Entity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity entity && entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
