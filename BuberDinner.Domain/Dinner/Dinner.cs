using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private Dinner(DinnerId dinnerId) : base(dinnerId)
    {

    }

    public static Dinner Create()
    {
        return new(DinnerId.CreateUnique());
    }
}
