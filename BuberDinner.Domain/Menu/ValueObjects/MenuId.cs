using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }

        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUnique() => new(Guid.NewGuid());

        public static MenuId Create(Guid value)
        {
            // TODO: enforce invariants
            return new MenuId(value);
        }

        //public static ErrorOr<MenuId> Create(string value)
        //{
        //    return !Guid.TryParse(value, out var guid) ? (ErrorOr<MenuId>)Errors.Menu.InvalidMenuId : (ErrorOr<MenuId>)new MenuId(guid);
        //}

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
