using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

    public static MenuReviewId Create(Guid value)
    {
        // TODO: enforce invariants
        return new MenuReviewId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
