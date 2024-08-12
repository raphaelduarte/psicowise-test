using System.Collections;

namespace Psicowise.Domain.Entities;

public abstract class Entity : IEquatable<Entity?>
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get;  set; }
    public bool Equals(Entity? other)
    {
        return other != null && Id == other.Id;
    }
}