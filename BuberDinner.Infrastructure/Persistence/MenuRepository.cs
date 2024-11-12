using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = [];

    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}
