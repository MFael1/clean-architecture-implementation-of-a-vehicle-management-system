namespace Motors.Domain.Common.Base;

public abstract class Entity
{
    
    protected Entity()
    {
    }
    
    public int Id { get; protected init; }

    
    public DateTimeOffset CreatedDate { get; private set; }
    public DateTimeOffset ModifiedDate { get; private set; }
    public bool IsActive { get; private set; } = true;

    
    public void SetCreatedDate()
    {
        CreatedDate = DateTimeOffset.UtcNow;
    }

    public void UpdateModifiedDate()
    {
        ModifiedDate = DateTimeOffset.UtcNow;
    }

    
    public virtual void Activate()
    {
        if (!IsActive)
        {
            IsActive = true;
        }
    }

    public void Deactivate()
    {
        if (IsActive)
        {
            IsActive = false;
        }    
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        
        var other = (Entity)obj;
        return Id == other.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Entity? left, Entity? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        return left.Equals(right);
    }

    public static bool operator !=(Entity? left, Entity? right) => !(left == right);
    
}