using BuberDinner.Domain.Menu;

namespace BuberDinner.Application.Common.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}
