using System.Reflection;

namespace Motors.Domain.Common.Base;

public abstract class Enumeration : IComparable
{
    public int Id { get; private set; }        // Numeric identifier
    public string Name { get; private set; }   // Display name

    protected Enumeration(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
        return typeof(T)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
            return false;
        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);
        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
    
    public static bool operator ==(Enumeration left, Enumeration right) => Equals(left, right);
    
    public static bool operator !=(Enumeration left, Enumeration right) => !Equals(left, right);
}