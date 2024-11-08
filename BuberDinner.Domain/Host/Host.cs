using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private Host(HostId hostId) : base(hostId)
    {

    }

    public static Host Creat()
    {
        return new(HostId.CreateUnique());
    }
}
