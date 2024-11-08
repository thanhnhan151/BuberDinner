using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    private MenuReview(MenuReviewId menuReviewId) : base(menuReviewId)
    {

    }

    public static MenuReview Create()
    {
        return new(MenuReviewId.CreateUnique());
    }
}
