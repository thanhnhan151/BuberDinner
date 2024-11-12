using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    private MenuItem(string name, string description)
        : base(MenuItemId.CreateUnique())
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(
        string name,
        string description)
    {
        return new(
            name,
            description);
    }

#pragma warning disable CS8618
    private MenuItem()
    {
    }
#pragma warning restore CS8618
}
