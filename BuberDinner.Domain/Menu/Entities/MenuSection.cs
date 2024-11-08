using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = [];

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public IReadOnlyList<MenuItem> Items => _items.ToList();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description)
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    public static MenuSection Create(
        string name,
        string description)
    {
        return new(
            MenuSectionId.CreateUnique(),
            name,
            description);
    }
}
