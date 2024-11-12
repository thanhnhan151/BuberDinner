using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.Events;

public record MenuCreated(Menu menu) : IDomainEvent;
