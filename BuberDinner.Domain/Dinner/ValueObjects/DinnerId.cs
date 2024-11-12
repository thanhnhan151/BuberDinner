using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class DinnerId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId Create(Guid value)
    {
        return new DinnerId(value);
    }

    public static DinnerId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private DinnerId()
    {
    }
#pragma warning restore CS8618
}
