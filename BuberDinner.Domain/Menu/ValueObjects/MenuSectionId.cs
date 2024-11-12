using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuSectionId : ValueObject
{
    public Guid Value { get; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

    public static MenuSectionId Create(Guid value)
    {
        // TODO: enforce invariants
        return new MenuSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
