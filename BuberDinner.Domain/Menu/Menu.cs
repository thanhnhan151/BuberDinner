using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.Events;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = [];
    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public AverageRating AverageRating { get; private set; }
    public HostId HostId { get; private set; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        AverageRating averageRating,
        List<MenuSection> sections)
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        AverageRating = averageRating;
        _sections = sections;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        List<MenuSection>? sections = null)
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            AverageRating.CreateNew(),
            sections ?? []);

        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;
    }

#pragma warning disable CS8618
    private Menu()
    {
    }
#pragma warning restore CS8618
}
